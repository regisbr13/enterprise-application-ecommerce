using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Core.Services;
using NSE.Customers.API.Application.EventHandlers;
using NSE.Customers.API.Configuration;
using NSE.Customers.API.Data;
using NSE.MessageBus;
using NSE.WebApiCore.Authentication;
using NSE.WebApiCore.Configuration;

namespace NSE.Customers.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        private const string ApiName = "Clientes";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomersContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddMediatrConfig();
            services.AddDependencyInjectionConfig();
            services.AddSwaggerConfiguration(ApiName);
            services.AddTokenConfiguration(Configuration);
            services.AddMessageBus(Configuration).AddHostedService<CustomerEventHandlerService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CustomersContext context)
        {
            if (env.IsDevelopment())
            {
                DatabaseService.SetUpDataBase(context);
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration(ApiName);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}