using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sofidy.Unicia.Application;
using Sofidy.Unicia.Infrastructure;
using Sofidy.Unicia.Infrastructure.Configurations.Options;
using Sofidy.Unicia.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Polling.Callback
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.ConfigureApplication(configuration);
            services.ConfigurePersistence(configuration);
            services.ConfigureApplicationServices();
            services.ConfigurePollingCallback(configuration);
            return services;
        }

        private static void ConfigurePollingCallback(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddOptions<PollingCallbackOption>()
                    .BindConfiguration<PollingCallbackOption>(PollingCallbackOption.Name);
        }
    }
}
