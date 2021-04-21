using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Core.Services;
using NSE.ShoppingCart.API.Configuration;
using NSE.ShoppingCart.API.Data;
using NSE.WebApiCore.Authentication;
using NSE.WebApiCore.Configuration;

namespace NSE.ShoppingCart.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private const string ApiName = "Carrinho de compras";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShoppingCartContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddMediatrConfig();
            services.AddDependencyInjectionConfig();
            services.AddSwaggerConfiguration(ApiName);
            services.AddTokenConfiguration(Configuration);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ShoppingCartContext context)
        {
            if (env.IsDevelopment())
            {
                DatabaseService.SetUpDataBase(context);
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