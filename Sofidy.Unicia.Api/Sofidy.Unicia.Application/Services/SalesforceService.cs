using Microsoft.Extensions.DependencyInjection;
using NetCoreForce.Models;
using Sofidy.Unicia.Application.Common.Exceptions;
using Sofidy.Unicia.Application.Services.Common;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Common;
using Sofidy.Unicia.Infrastructure.Client.SalesforceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services
{
    public class SalesforceService : BaseApplicationService, ISalesforceService
    {
        private readonly ISalesforceClient _salesforceClient; 

        public SalesforceService(ISalesforceClient salesforceClient)
        {
            _salesforceClient = salesforceClient;
        }
        
        public async Task UpdateCallbackSObject<T>(string cType, string idSObject, Action<T> action)
        {
            string sObjectTypeName = DomainConstants.GetSObjectTypeNameByEntity(cType);
            var client = _salesforceClient.GetInstance();

            //Get
            T sObject = await client.GetObjectById<T>(sObjectTypeName, idSObject);
            if (sObject == null)
                throw new OperationArgumentNullException($"Salesforce {sObjectTypeName} : {idSObject}");

            if(action != null)
                action(sObject);

            await client.UpdateRecord<T>(sObjectTypeName, idSObject, sObject); 
        }
    }
}
