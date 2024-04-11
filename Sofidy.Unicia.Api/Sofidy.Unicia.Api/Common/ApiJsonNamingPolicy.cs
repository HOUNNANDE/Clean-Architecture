using Sofidy.Unicia.Api.Extensions;
using System.Text.Json;

namespace Sofidy.Unicia.Api.Common
{
    public abstract class ApiJsonNamingPolicy : JsonNamingPolicy
    { 
        public static JsonNamingPolicy SnakeCase { get; } = new JsonSnakeCaseNamingPolicy();  
    }

    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static string ToSnakeCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        public override string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }
    }
}
