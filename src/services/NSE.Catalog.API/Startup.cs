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

namespace NSE.Catalog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatalogContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDependencyInjectionConfig();
            services.AddSwaggerConfiguration();
            services.AddTokenConfiguration(Configuration);

            //services.AddCors(opt => opt.AddPolicy("Development", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CatalogContext context)
        {
            if (env.IsDevelopment())
            {
                DatabaseService.SetUpDataBase(context);
                SeedService.Seed(context);
                //app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();
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