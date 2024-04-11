using NetCoreForce.Client.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services.DTO.SalesforceService.SObjectModel
{
    public record SfUniciaTracableObject
    {
        [JsonIgnore]
        public static string SObjectTypeName
        {
            get { return "Account"; }
        }

        ///<summary>
		/// Account ID
		/// <para>Name: Id</para>
		/// <para>SF Type: id</para>
		/// <para>Nillable: False</para>
		///</summary>
		[JsonProperty(PropertyName = "id")]
        [Updateable(false), Createable(false)]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "NumeroAssocie__c")]
        [Updateable(true), Createable(true)]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "Partenaire_Code_Agent__c")]
        [Updateable(true), Createable(true)]
        public string IdUnicia { get; set; }

        [JsonProperty(PropertyName = "Synchronisation_avec_Unicia__c")]
        [Updateable(true), Createable(true)]
        public string UniciaSyncStatus { get; set; }
    }
}
