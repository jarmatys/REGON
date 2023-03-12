using Microsoft.Extensions.DependencyInjection;
using REGON.Services;

namespace REGON
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRegonClient(this IServiceCollection services, string apiKey)
        {
            services.AddTransient<IRegonClient>(provider => new RegonClient(apiKey));

            return services;
        }
    }
}