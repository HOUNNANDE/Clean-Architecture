
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sofidy.Unicia.Application.Common.Behaviors;
using Sofidy.Unicia.Application.Services;
using Sofidy.Unicia.Application.Services.Common;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Common;
using System;
using System.Reflection;
using static FluentValidation.AssemblyScanner;

namespace Sofidy.Unicia.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Add MediatR
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); 
                //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            // Add Validator
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Add 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Dynamic register
            services.ConfigureTypeAsInterfaceFromAssembly(namespaceTarget: "Sofidy.Unicia.Application.Services",
                                                               baseOnType: new[] { typeof(BaseApplicationDbContextService), typeof(BaseApplicationService) });
 
      

            // Add services to the container.
            return services;
        }
    }
}
