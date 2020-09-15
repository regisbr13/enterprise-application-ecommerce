using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.Mvc.Extensions;
using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Services;
using NSE.WebApp.Mvc.Services.Handlers;
using Polly;
using Polly.Extensions.Http;
using Refit;
using System;

namespace NSE.WebApp.Mvc.Configuration
{
    public static class HttpClientConfig
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.Get<AppSettings>();
            services.AddHttpClient<IAuthService, AuthService>(opt => opt.BaseAddress = new Uri(settings.AuthenticationUrl));

            services.AddHttpClient("CatalogRefit", opt => opt.BaseAddress = new Uri(settings.CatalogUrl))
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddTypedClient(RestService.For<ICatalogService>)
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(1, TimeSpan.FromSeconds(10)));

            return services;
        }
    }
}