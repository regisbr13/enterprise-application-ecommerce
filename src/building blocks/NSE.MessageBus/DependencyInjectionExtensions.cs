using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NSE.MessageBus
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MessageQueueConnection") ??
                throw new NullReferenceException("Verifique o arquivo de configuração MessageQueueConnectionString");

            services.AddSingleton<IMessageBus>(new MessageBus(connectionString));
            return services;
        }
    }
}