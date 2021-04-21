using Microsoft.Extensions.DependencyInjection;
using NSE.Customers.API.Data;
using NSE.Customers.API.Data.Repository;
using NSE.Customers.API.Interfaces;

namespace NSE.Customers.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<CustomersContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}