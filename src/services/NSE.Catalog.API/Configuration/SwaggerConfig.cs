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

                var security = new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT dessa maneira: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                };

                opt.AddSecurityDefinition("Bearer", security);

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme }
                    },
                    new string[] {}
                    }
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