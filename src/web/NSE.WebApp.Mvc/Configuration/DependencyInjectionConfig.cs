using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Extensions;
using NSE.WebApp.Mvc.Services.Handlers;

namespace NSE.WebApp.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUser, AspNetUser>();

            return services;
        }
    }
}