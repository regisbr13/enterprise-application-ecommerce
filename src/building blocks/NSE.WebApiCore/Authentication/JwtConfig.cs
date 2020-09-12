using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NSE.WebApiCore.Authentication
{
    public static class JwtConfig
    {
        public static IServiceCollection AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenSettingsSection = configuration.GetSection("TokenSettings");
            services.Configure<TokenSettings>(tokenSettingsSection);
            var tokenSettings = tokenSettingsSection.Get<TokenSettings>();
            var secretKey = Encoding.ASCII.GetBytes(tokenSettings.Secret);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = tokenSettings.ValidUri,
                    ValidIssuer = tokenSettings.Issuer
                };
            });
            services.AddSingleton(x => x.GetRequiredService<IOptions<TokenSettings>>().Value);

            return services;
        }
    }
}