using NetCoreForce.Client;
using Sofidy.Unicia.Infrastructure.Configurations.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreForce.Client.Models;

namespace Sofidy.Unicia.Infrastructure.Client.SalesforceClient
{
    public class SalesforceClient : ISalesforceClient
    {
        public AuthInfo AuthInfo { get; set; }

        public SalesforceClient(AuthInfo authinfo) 
        { 
            AuthInfo= authinfo;
        }

        public ForceClient GetInstance() => new ForceClient(this.AuthInfo);
    }
}
