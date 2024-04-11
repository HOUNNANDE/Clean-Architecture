using NetCoreForce.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services.Interfaces
{
    public interface ISalesforceService
    {
        Task UpdateCallbackSObject<T>(string cType, string idSObject, Action<T> action);
    }
}
