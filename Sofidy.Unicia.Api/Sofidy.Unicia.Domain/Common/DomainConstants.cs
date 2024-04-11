using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Domain.Common
{
    public class DomainConstants
    {
        /// <summary>
        /// Mapping Entity Unicia / ITyParam 
        /// </summary>
        internal static readonly Dictionary<String, ITyParam> Mapping_Entity_IConvertITyParam = new()
        {
            { nameof(ImportAgent), ITyParam.IConvert_Agent },
            { nameof(ImportClient), ITyParam.IConvert_Client}
        };

        /// <summary>
        /// Mapping Entity Unicia / Salesforce Object  
        /// </summary>
        internal static readonly Dictionary<string, string> Mapping_Entity_SObjectTypeName = new()
        {
            { nameof(ImportAgent), "Account" },
            { nameof(ImportClient), "Account" },
        };

        public static string GetSObjectTypeNameByEntity(string entityTypeName)
            => Mapping_Entity_SObjectTypeName[entityTypeName];

        public static string GetSObjectTypeNameByEntity<T>()
            => GetSObjectTypeNameByEntity(typeof(T).Name);

        public static ITyParam GetITyPramByEntity(string entityTypeName)
            => Mapping_Entity_IConvertITyParam[entityTypeName];

        public static ITyParam GetITyPramByEntity<T>()
            => GetITyPramByEntity(typeof(T).Name);
    }

    public enum ImportStatus
    {
        OK = 1,
        KO = 0,
        None = -1,
    }

    public static class EntityColumnType
    {
        public const string Decimal_ZeroPrecision = "decimal(18, 0)";
    }

}
