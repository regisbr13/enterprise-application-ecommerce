using Microsoft.Extensions.DependencyInjection;
using NSE.Customers.API.Data;

namespace NSE.Customers.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<CustomersContext>();
            return services;
        }
    }
}