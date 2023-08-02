using Microsoft.Extensions.DependencyInjection;
using REGON.Client.Services;

namespace REGON.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRegonClient(this IServiceCollection services, string apiKey)
        {
            services.AddTransient<IRegonClient>(_ => new RegonClient(apiKey));

            return services;
        }
    }
}