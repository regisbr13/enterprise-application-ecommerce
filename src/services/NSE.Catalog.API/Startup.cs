using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Catalog.API.Configuration;
using NSE.Catalog.API.Data;
using NSE.Catalog.API.Services;
using NSE.Core.Services;
using NSE.WebApiCore.Authentication;
using NSE.WebApiCore.Configuration;

namespace NSE.Catalog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private const string ApiName = "Catálogo";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatalogContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddDependencyInjectionConfig();
            services.AddSwaggerConfiguration(ApiName);
            services.AddTokenConfiguration(Configuration);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CatalogContext context)
        {
            if (env.IsDevelopment())
            {
                DatabaseService.SetUpDataBase(context);
                SeedService.Seed(context);
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration(ApiName);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}