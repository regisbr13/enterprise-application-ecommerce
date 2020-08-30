using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NSE.WebApp.Mvc.Configuration
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AddMyAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/entrar";
                    opt.AccessDeniedPath = "/acesso-negado";
                });

            return services;
        }

        public static IApplicationBuilder UseMyAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}