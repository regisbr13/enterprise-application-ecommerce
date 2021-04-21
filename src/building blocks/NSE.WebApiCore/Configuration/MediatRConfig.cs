using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApiCore.Validations;
using System.Reflection;

namespace NSE.WebApiCore.Configuration
{
    public static class MediatRConfig
    {
        public static IServiceCollection AddMediatrConfig(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());
            services.AddMediatR(Assembly.GetCallingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            return services;
        }
    }
}