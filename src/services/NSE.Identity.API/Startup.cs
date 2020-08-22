using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Identity.API.Configuration;
using NSE.Identity.API.Data;
using NSE.Identity.API.Extensions;

namespace NSE.Identity.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DatabaseService>();
            services.AddIdentityConfiguration();
            services.AddTokenConfiguration(Configuration);

            services.AddControllers().ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseService databaseService)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            databaseService.CreateDatabase();

            app.UseSwaggerConfiguration();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseIdentityConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}