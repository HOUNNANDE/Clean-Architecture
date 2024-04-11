using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Sofidy.Unicia.Api.Extensions
{
    public static class SerilogExtensions
    {
        public static IHostBuilder UseLoggingSetup(this IHostBuilder host, IConfiguration configuration, IHostEnvironment environment)
        {
            host.UseSerilog((_, _, lc) =>
            {
                lc.ReadFrom.Configuration(configuration);
            }); 
             
            if (environment.IsProduction())
            {
                // Remove after Fix SSL Splunk
                HttpClientHandler clientHandler = new HttpClientHandler()
                {
                    //dont remove!! ask Adrien COUDRET => System.Net.Http.DangerousAcceptAnyServerCertificateValidator
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
                };
            }

            return host;
        }
    }
}
