using Microsoft.Extensions.DependencyInjection;
using NSE.Catalog.API.Data;
using NSE.Catalog.API.Data.Repository;
using NSE.Catalog.API.Interfaces;

namespace NSE.Catalog.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CatalogContext>();

            return services;
        }
    }
}