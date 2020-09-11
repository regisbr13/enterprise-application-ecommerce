using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Catalog.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
            => services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("catalogo", new OpenApiInfo
                {
                    Title = "Api de Catálogo",
                    Contact = new OpenApiContact { Name = "Regis / Ivan", Email = "suporte@mail.com" }
                });
            });

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/catalogo/swagger.json", "Api de Catálogo"));

            return app;
        }
    }
}