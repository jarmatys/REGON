using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using REGON.Enums;
using REGON.Models;

namespace REGON
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
        
        public async Task<RegonResponse> GetBasicCompanyData(string nip)
        {
            ValidateInput(nip);

            var basicData = await _httpClient.SzukajPodmiotuByNip(nip);

            if (basicData.Dane.Nazwa == null)
            {
                return null;
            }

            return new RegonResponse
            {
                NIP = basicData.Dane.Nip,
                REGON = basicData.Dane.Regon,
                Name = basicData.Dane.Nazwa,
                City = basicData.Dane.Miejscowosc,
                PostCode = basicData.Dane.KodPocztowy,
                Street = basicData.Dane.Ulica,
                FlatNumber = basicData.Dane.NrLokalu,
                BuildingNumber = basicData.Dane.NrNieruchomosci
            };
        }

        private async Task<RegonResponse> CreateRegonResponse(DaneSzukajPodmioty basicData)
        {
            if (basicData.Nazwa == null)
            {
                return null;
            }

            var legalForm = CheckLegalForm(basicData.Nazwa, basicData.Typ);
            var pkds = await GetPkds(legalForm, basicData.Regon?.ToString());

            var advancedReportData = await GetAdvanceReportData(legalForm, basicData.Regon?.ToString());

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
                StartDate = advancedReportData?.StartDate != null ? advancedReportData.StartDate.Value : DateTime.Now,
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
                default:
                    return null;
            }
        }
        private async Task<PkdModel> GetPkdForPhysicalPerson(string regon)
        {
            var pkds = await _httpClient.PobierzPKDFizyczna(regon);

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
            if (type == "P" && companyName.ToUpper().Contains("SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ") && companyName.ToUpper().Contains("SPÓŁKA KOMANDYTOWA")) return LegalForm.SPZOOSK;
            else if (type == "P" && IsSPZOO(companyName)) return LegalForm.SPZOO;
            else if (type == "P" && companyName.ToUpper().Contains("SPÓŁKA AKCYJNA")) return LegalForm.SA;
            else if (type == "P" && companyName.ToUpper().Contains("SPÓŁKA JAWNA")) return LegalForm.SJ;
            else if (type == "P" && companyName.ToUpper().Contains("SPÓŁKA KOMANDYTOWO - AKCYJNA")) return LegalForm.SKA;
            else if (type == "P" && companyName.ToUpper().Contains("SPÓŁKA KOMANDYTOWA")) return LegalForm.SK;
            else if ((type == "F" || type == "P") && (companyName.ToUpper().Contains("SPÓŁKA CYWILNA") || companyName.ToUpper().Contains("S.C"))) return LegalForm.SC;
            else if (type == "F") return LegalForm.JDG;
            else return LegalForm.ERROR;
        }
        public static bool IsSPZOO(string companyName)
        {
            return companyName.ToUpper().Contains("SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ") || companyName.ToUpper().Contains("SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIANOŚCIĄ");
        }
    }

    public class PkdModel
    {
        public Pkd MainPkd { get; set; }
        public List<Pkd> RestPkds { get; set; }
    }

    public class AdvanceReportData
    {
        public bool IsSuspended { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
