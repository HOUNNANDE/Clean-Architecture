using NetCoreForce.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Client.SalesforceClient
{
    public record SalesforceClientConfiguration
    {
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string ApiVersion { get; init; }  
        public string Host { get; init; }
        public string TokenRequestEndpointUrl 
        { 
            get 
            {
                if (string.IsNullOrEmpty(Host))
                    return "https://login.salesforce.com/services/oauth2/token";

                return $"https://{Host}/services/oauth2/token";
            } 
        }  

        public AuthInfo AuthInfo
        {
            get
            {
                return new AuthInfo()
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret,
                    ApiVersion = ApiVersion,
                    Password = Password,
                    Username = Username,
                    TokenRequestEndpoint = TokenRequestEndpointUrl 
                };
            }
        }
    }
}
