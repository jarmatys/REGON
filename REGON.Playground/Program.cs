using Microsoft.Extensions.DependencyInjection;
using REGON.Client;
using REGON.Client.Services;

namespace REGON.Playground
{
    public abstract class Program
    {
        private const string GusKey = "<YOUR-GUS-KEY>";
        
        private static async Task Main(string[] args)
        {
            Console.WriteLine("REGON PLAYGROUND - START");
            
            var client = GetRegonClient();
            
            const string exampleKrs = "0000709622";
            
            var regonResponse = await client.GetCompanyDataByKrs(exampleKrs);            

            Console.WriteLine("REGON PLAYGROUND - END");
        }

        private static IRegonClient GetRegonClient()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddRegonClient(GusKey);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider.GetService<IRegonClient>()!;
        }
    }
}