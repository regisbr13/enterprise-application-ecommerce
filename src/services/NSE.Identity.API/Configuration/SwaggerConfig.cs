using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Identity.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
            => services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("identidade", new OpenApiInfo
                {
                    Title = "Api de Identidade",
                    Contact = new OpenApiContact { Name = "Regis / Ivan", Email = "suporte@mail.com" }
                });
            });

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/identidade/swagger.json", "Api de Identidade"));

            return app;
        }
    }
}