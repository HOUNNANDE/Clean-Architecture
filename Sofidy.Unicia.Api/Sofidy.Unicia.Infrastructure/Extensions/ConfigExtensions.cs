using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sofidy.Unicia.Infrastructure.Configurations.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Extensions
{
    public static class ConfigExtensions
    {
        public static IHostBuilder UseAppSettings(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(conf => {

                conf
                   .AddEnvironmentVariables()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                AppSettingsOption option = new();
                conf.Build()
                    .GetSection(AppSettingsOption.Name)
                    .Bind(option);

                if (option != null && option.Files.Any())
                {
                    option.Files.ForEach(pattern =>
                    {
                        conf.AddJsonFile($"appsettings.{pattern}.json", optional: false, reloadOnChange: true);
                    });
                }
            });

            return host;
        }
    }
}
