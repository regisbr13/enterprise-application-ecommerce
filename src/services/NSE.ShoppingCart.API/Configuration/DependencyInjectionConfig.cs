using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSE.ShoppingCart.API.Data;
using NSE.ShoppingCart.API.Data.Repository;
using NSE.ShoppingCart.API.Interfaces;
using NSE.WebApiCore.User;

namespace NSE.ShoppingCart.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<ShoppingCartContext>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IItemShoppingCartRepository, ItemShoppingCartRepository>();

            return services;
        }
    }
}