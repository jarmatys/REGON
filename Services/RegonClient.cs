using REGON.Enums;
using REGON.Models;
using REGON.Responses;

namespace REGON.Services
{
    public class RegonClient : IRegonClient
    {
        private readonly Client _clientRegon;

        public RegonClient(string apiKey)
        {
            _clientRegon = new Client(apiKey);
        }

        public async Task<Company> GetCompanyDataByNip(string nip)
        {
            try
            {
                var response = await _clientRegon.GetFullCompanyDataByNip(nip);

                if (response != null)
                {
                    return CreateRegonResult(response);
                }

                return new Company();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Problem z połączeniem do API REGON'u.", ex);
            }
        }
        
        public async Task<Company> GetCompanyDataByKrs(string krs)
        {
            try
            {
                var response = await _clientRegon.GetFullCompanyDataByKrs(krs);

                if (response != null)
                {
                    return CreateRegonResult(response);
                }

                return new Company();
            }
            catch (Exception ex)
            {
                throw new Exception("Problem z połączeniem do API REGON'u.", ex);
            }
        }

        private static Company CreateRegonResult(RegonResponse response)
        {
            var pkds = new List<Pkd>();
            if (response.Pkds != null)
            {
                foreach (var pkd in response.Pkds)
                {
                    pkds.Add(new Pkd { Value = pkd.Value, Name = pkd.Name });
                }
            }
            
            var legalForm = (LegalForm)Enum.Parse(typeof(LegalForm), response.LegalForm);

            return new Company
            {
                Nip = response.NIP,
                Krs = response.Krs,
                Name = response.Name,
                REGON = response.REGON,
                BuildingNumber = response.BuildingNumber,
                FlatNumber = response.FlatNumber,
                City = response.City,
                PostCode = response.PostCode,
                LegalForm = legalForm,
                Street = response.Street,
                MainPkd = response.MainPkd?.Value,
                Pkds = pkds,
                StartDate = response.StartDate,
                EndDate = response.EndDate,
                IsSuspended = response.IsSuspended,
                Voivodeship = response.Voivodeship,
                District = response.District,
                Commune = response.Commune,
                WebsiteUrl = response.WebsiteUrl,
                Email = response.Email,
                PhoneNumber = response.PhoneNumber,
            };
        }
    }
}
