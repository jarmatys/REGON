using System.Threading.Tasks;
using REGON.Infrastructure.Responses;

namespace REGON.Client.Services
{
    public interface IRegonClient
    {
        Task<Company> GetCompanyDataByNip(string nip);
        Task<Company> GetCompanyDataByKrs(string krs);
    }
}
