using static System.Net.WebRequestMethods;

namespace Sofidy.Unicia.Infrastructure.Configurations.Options
{
    public record SalesforceOption
    {
        public const string Name = "Salesforce";
        public SalesforceApi RestApi { get; set; }
    }

    public record SalesforceApi
    {
        public string Protocol { get; set; } = "https";
        public string Host { get; set; }
        public string Version { get; set; } = "v57.0";
        public string GrantType { get; set; } = "password";
        public string Password { get; set; }
        public string Username { get; set; }
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }

        public string AuthUrl => $"{Protocol}://{Host}/services/oauth2/token";

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(ClientId) &&
                   !string.IsNullOrEmpty(ClientSecret);
        }
    }

}
