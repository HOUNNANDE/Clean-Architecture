using System.Text.Json.Serialization;
using System.Text.Json;
using Sofidy.Unicia.Api.Common; 

namespace Sofidy.Unicia.Api.Extensions
{
    public static class TextExtension
    {
        public static IServiceCollection AddJsonOptions(this IServiceCollection services)
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = ApiJsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = ApiJsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                MaxDepth = 10,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            serializerOptions.Converters.Add(new JsonStringEnumConverter());
            services.AddSingleton(s => serializerOptions); 

            return services;
        }
         
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
     
    }
     
}
