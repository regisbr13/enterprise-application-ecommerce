using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Extensions;

namespace NSE.WebApp.Mvc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUser, AspNetUser>();

            return services;
        }
    }
}