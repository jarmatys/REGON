using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using REGON.Common.Enums;
using REGON.Infrastructure.Models;

namespace REGON.Infrastructure
{
    public class Client
    {
        private readonly HttpClient _httpClient;

        public Client(string apiKey)
        {
            _httpClient = new HttpClient(apiKey);
        }

        public async Task<RegonResponse> GetFullCompanyDataByNip(string nip)
        {
            ValidateInput(nip);

            var basicData = await _httpClient.SzukajPodmiotuByNip(nip);

            return await CreateRegonResponse(basicData.Dane);
        }

        public async Task<RegonResponse> GetFullCompanyDataByKrs(string krs)
        {
            ValidateInput(krs);

            var basicData = await _httpClient.SzukajPodmiotuByKrs(krs);

            return await CreateRegonResponse(basicData.Dane);
        }

        private async Task<RegonResponse> CreateRegonResponse(DaneSzukajPodmioty basicData)
        {
            if (basicData.Nazwa == null)
            {
                return null;
            }

            var legalForm = CheckLegalForm(basicData.Nazwa, basicData.Typ);
            var pkds = await GetPkds(legalForm, basicData.Regon);

            var advancedReportData = await GetAdvanceReportData(legalForm, basicData.Regon);

            return new RegonResponse
            {
                NIP = basicData.Nip,
                Krs = "",
                REGON = basicData.Regon,
                LegalForm = legalForm.ToString(),
                Name = basicData.Nazwa.Replace("\"", "'"),
                City = basicData.Miejscowosc,
                PostCode = basicData.KodPocztowy,
                Street = basicData.Ulica,
                FlatNumber = basicData.NrLokalu,
                BuildingNumber = basicData.NrNieruchomosci,
                MainPkd = pkds?.MainPkd,
                Pkds = pkds?.RestPkds,
                Commune = basicData.Gmina,
                District = basicData.Powiat,
                Voivodeship = basicData.Wojewodztwo,
                IsSuspended = advancedReportData == null || advancedReportData.IsSuspended,
                IsActive = IsActive(basicData.Nazwa),
                StartDate = advancedReportData?.StartDate ?? DateTime.Now,
                EndDate = advancedReportData?.EndDate,
                WebsiteUrl = advancedReportData?.WebsiteUrl,
                Email = advancedReportData?.Email,
                PhoneNumber = advancedReportData?.PhoneNumber
            };
        }

        private async Task<PkdModel> GetPkds(LegalForm legalForm, string regon)
        {
            switch (legalForm)
            {
                case LegalForm.JDG:
                case LegalForm.SC:
                    return await GetPkdForPhysicalPerson(regon);
                case LegalForm.SPZOO:
                case LegalForm.SA:
                case LegalForm.SPZOOSK:
                case LegalForm.SJ:
                case LegalForm.SKA:
                case LegalForm.SK:
                    return await GetPkdForLegalPerson(regon);
                case LegalForm.ERROR:
                default:
                    return null;
            }
        }

        private async Task<PkdModel> GetPkdForPhysicalPerson(string regon)
        {
            var pkds = await _httpClient.PobierzPkdFizyczna(regon);

            var result = new PkdModel();
            var pkdList = new List<Pkd>();

            foreach (var pkd in pkds.Dane)
            {
                if (pkd.FizPkdPrzewazajace == 1)
                {
                    result.MainPkd = new Pkd { Value = pkd.FizPkdKod, Name = pkd.FizPkdNazwa };
                }

                pkdList.Add(new Pkd { Value = pkd.FizPkdKod, Name = pkd.FizPkdNazwa });
            }

            result.RestPkds = pkdList;

            return result;
        }

        private async Task<PkdModel> GetPkdForLegalPerson(string regon)
        {
            var pkds = await _httpClient.PobierzPKDPrawna(regon);

            var result = new PkdModel();
            var pkdList = new List<Pkd>();

            foreach (var pkd in pkds.Dane)
            {
                if (pkd.PrawPkdPrzewazajace == 1)
                {
                    result.MainPkd = new Pkd { Value = pkd.PrawPkdKod, Name = pkd.PrawPkdNazwa };
                }

                pkdList.Add(new Pkd { Value = pkd.PrawPkdKod, Name = pkd.PrawPkdNazwa });
            }

            result.RestPkds = pkdList;

            return result;
        }

        private async Task<AdvanceReportData> GetAdvanceReportData(LegalForm legalForm, string regon)
        {
            switch (legalForm)
            {
                case LegalForm.JDG:
                case LegalForm.SC:
                    return await GetReportForPhyisicalPerson(regon);
                case LegalForm.SPZOO:
                case LegalForm.SA:
                case LegalForm.SPZOOSK:
                case LegalForm.SJ:
                case LegalForm.SKA:
                case LegalForm.SK:
                    return await GetReportForLegalPerson(regon);
                case LegalForm.ERROR:
                default:
                    return null;
            }
        }

        private async Task<AdvanceReportData> GetReportForPhyisicalPerson(string regon)
        {
            var fullReport = await _httpClient.PobierzPelnyRaportCeidg(regon);

            return new AdvanceReportData
            {
                StartDate = GetDate(fullReport.Dane.FizDataPowstania),
                EndDate = GetDate(fullReport.Dane.FizDataZakonczeniaDzialalnosci),
                IsSuspended = IsHappened(fullReport.Dane.FizDataZawieszeniaDzialalnosci),
                PhoneNumber = ValueOrNull(fullReport.Dane.FizNumerTelefonu),
                WebsiteUrl = ValueOrNull(fullReport.Dane.FizAdresStronyinternetowej),
                Email = ValueOrNull(fullReport.Dane.FizAdresEmail)
            };
        }

        private async Task<AdvanceReportData> GetReportForLegalPerson(string regon)
        {
            var fullReport = await _httpClient.PobierzPelnyRaportPrawna(regon);

            return new AdvanceReportData
            {
                StartDate = GetDate(fullReport.Dane.PrawDataPowstania),
                EndDate = GetDate(fullReport.Dane.PrawDataZakonczeniaDzialalnosci),
                IsSuspended = IsHappened(fullReport.Dane.PrawDataZawieszeniaDzialalnosci),
                PhoneNumber = ValueOrNull(fullReport.Dane.PrawNumerTelefonu),
                WebsiteUrl = ValueOrNull(fullReport.Dane.PrawAdresStronyinternetowej),
                Email = ValueOrNull(fullReport.Dane.PrawAdresEmail)
            };
        }

        private static DateTime? GetDate(string dateTime)
        {
            return !string.IsNullOrEmpty(dateTime) ? Convert.ToDateTime(dateTime) : null;
        }

        private static bool IsHappened(string dateTime)
        {
            return !string.IsNullOrEmpty(dateTime);
        }

        private static string ValueOrNull(string value)
        {
            return !string.IsNullOrEmpty(value) ? value : null;
        }

        private static void ValidateInput(string nip)
        {
            if (string.IsNullOrEmpty(nip))
            {
                throw new Exception("[REGON] NIP/KRS is required parameter!");
            }
        }

        private static LegalForm CheckLegalForm(string companyName, string type)
        {
            return type switch
            {
                "P" when companyName.ToUpper().Contains("SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ") &&
                         companyName.ToUpper().Contains("SPÓŁKA KOMANDYTOWA") => LegalForm.SPZOOSK,
                "P" when IsSpzoo(companyName) => LegalForm.SPZOO,
                "P" when companyName.ToUpper().Contains("SPÓŁKA AKCYJNA") => LegalForm.SA,
                "P" when companyName.ToUpper().Contains("SPÓŁKA JAWNA") => LegalForm.SJ,
                "P" when companyName.ToUpper().Contains("SPÓŁKA KOMANDYTOWO - AKCYJNA") => LegalForm.SKA,
                "P" when companyName.ToUpper().Contains("SPÓŁKA KOMANDYTOWA") => LegalForm.SK,
                "F" or "P" when (companyName.ToUpper().Contains("SPÓŁKA CYWILNA") ||
                                 companyName.ToUpper().Contains("S.C")) => LegalForm.SC,
                "F" => LegalForm.JDG,
                _ => LegalForm.ERROR
            };
        }

        private static bool IsSpzoo(string companyName)
        {
            return companyName.ToUpper().Contains("SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ") ||
                   companyName.ToUpper().Contains("SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIANOŚCIĄ") ||
                   companyName.ToUpper().Contains("SPÓŁKA Z OGRANICZONA ODPOWIEDZIALNOŚCIĄ");
        }

        private static bool IsActive(string companyName)
        {
            if (!IsSpzoo(companyName)) return true;

            return !(companyName.ToUpper().Contains("W LIKWIDACJI") || companyName.ToUpper().Contains("LIKWIDACYJNEJ"));
        }
    }

    public class PkdModel
    {
        public Pkd MainPkd { get; set; }
        public List<Pkd> RestPkds { get; set; }
    }

    public class AdvanceReportData
    {
        public bool IsSuspended { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string WebsiteUrl { get; init; }
    }
}