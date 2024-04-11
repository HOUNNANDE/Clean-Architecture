using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Sofidy.Unicia.Infrastructure.Common
{
    /// <summary>
    /// Dynamic Dependency Injection 
    /// </summary>
    public static class ServiceExtensionsHelper
    {
        public static IServiceCollection ConfigureTypeAsInterfaceFromAssembly(this IServiceCollection services,
                                                                                              string? namespaceTarget,
                                                                                              Type[]? baseOnType,
                                                                                                 bool isBaseOnGenericType = false, 
                                                                                      ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            if (string.IsNullOrEmpty(namespaceTarget))
                throw new ArgumentNullException($"{namespaceTarget} can not be empty.");

            var lstClass = from type in Assembly.GetCallingAssembly().GetTypes()
                           where type.Namespace != null && type.Namespace.EndsWith(namespaceTarget)
                           select type;

            var query = from type in lstClass
                        where !type.IsAbstract && !type.IsGenericTypeDefinition
                        let interfaces = type.GetInterfaces()
                        let matchingInterface = interfaces.Where(i => !i.IsGenericType).FirstOrDefault()
                        let isBaseOnType =  baseOnType == null   || 
                                           ( isBaseOnGenericType && !type.IsNested && !type.IsAbstract && type.BaseType != null && baseOnType.Contains(type.BaseType.GetGenericTypeDefinition())) ||
                                           ( !isBaseOnGenericType && baseOnType.Contains(type.BaseType) ) 
                        where matchingInterface != null && isBaseOnType
                        select new KeyValuePair<Type, Type>(matchingInterface, type);

            foreach (var kv in query)
            { 
                services.Add(new ServiceDescriptor(kv.Key, kv.Value, lifetime));
            }

            return services;
        }
    }
}
