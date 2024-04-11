using Microsoft.Extensions.Options;
using Sofidy.Unicia.Api.Configurations.Options;
using Sofidy.Unicia.Application;
using Sofidy.Unicia.Infrastructure;
using Sofidy.Unicia.Infrastructure.Configurations.Options;
using Sofidy.Unicia.Infrastructure.Persistence;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sofidy.Unicia.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddOptions<SwaggerOption>()
                    .BindConfiguration(SwaggerOption.Name); 

            services.ConfigureApplication(configuration);

            services.ConfigurePersistence(configuration);

            services.ConfigureApplicationServices();

            // Add services to the container.
            return services;
        }
    }
}
