using AutoMapper;
using CloudyMobile.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace CloudyMobile.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), 
                typeof(ValidationBehaviour<,>));
            
            services.AddTransient(typeof(IPipelineBehavior<,>), 
                typeof(LoggingBehaviour<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(UnhandledExceptionBehaviour<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(PerformanceBehaviour<,>));

            return services;
        }
    }
}