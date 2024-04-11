using Microsoft.Extensions.DependencyInjection;
using NetCoreForce.Client;
using Sofidy.Unicia.Infrastructure.Configurations.Options;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Sofidy.Unicia.Infrastructure.Client.SalesforceClient;
using LazyProxy.ServiceProvider;
using NetCoreForce.Client.Models;
using System.Security.Principal;
using System.Net.Sockets;
using NetCoreForce.Models;
using Sofidy.Unicia.Application.Services.DTO.SalesforceService.SObject;

namespace Sofidy.Unicia.Infrastructure
{
    public static class ServiceExtensions
    { 
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSalesforceClient(configuration);
        }
       

        private static void ConfigureSalesforceClient(this IServiceCollection services, IConfiguration configuration)
        { 
            //configuration.GetSection(SalesforceOption.Name)
            //             .Get<SalesforceOption>(); 

            var option = configuration.GetSection(SalesforceOption.Name)
                                                .Get<SalesforceOption>();  
            if (option == null)
                throw new ArgumentNullException("Configuration Salesforce is null or empty");

            var salesforceConfiguration = new SalesforceClientConfiguration() with
            {
                ClientId = option.RestApi.ClientId,
                ClientSecret = option.RestApi.ClientSecret,
                Password = option.RestApi.Password,
                Username = option.RestApi.Username,
                Host = option.RestApi.Host,
                ApiVersion = option.RestApi.Version
            };
            services.AddSingleton<AuthInfo>(salesforceConfiguration.AuthInfo);
            services.AddLazyScoped<ISalesforceClient, SalesforceClient>();  
        }
    }
}

