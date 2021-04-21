using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApiCore.User;
using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Services;
using NSE.WebApp.Mvc.Services.Handlers;

namespace NSE.WebApp.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAspNetUser, AspNetUser>();

            return services;
        }
    }
}