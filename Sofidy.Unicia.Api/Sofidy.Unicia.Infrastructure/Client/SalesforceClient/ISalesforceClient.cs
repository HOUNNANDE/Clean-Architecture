using NetCoreForce.Client;
using NetCoreForce.Client.Models;

namespace Sofidy.Unicia.Infrastructure.Client.SalesforceClient
{
    public interface ISalesforceClient
    {
        AuthInfo AuthInfo { get; set; }
        ForceClient GetInstance(); 
    }
}