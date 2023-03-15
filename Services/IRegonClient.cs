using System.Threading.Tasks;
using REGON.Responses;

namespace REGON.Services
{
    public interface IRegonClient
    {
        Task<Company> GetCompanyDataByNip(string nip);
        Task<Company> GetCompanyDataByKrs(string krs);
    }
}
