using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.Mvc.Extensions;
using NSE.WebApp.Mvc.Interfaces;
using System;

namespace NSE.WebApp.Mvc.Configuration
{
    public static class HttpClienteConfig
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.Get<AppSettings>();
            services.AddHttpClient<IAuthService, AuthService>(opt => opt.BaseAddress = new Uri(settings.AuthenticationUrl));

            return services;
        }
    }
}