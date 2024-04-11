using System.Text.Json;

namespace Sofidy.Unicia.Api.Extensions
{ 
    public static class MvcExtensions
    {
        public static void AddMVCControllers(this IServiceCollection services)
        {
            var jsonSerializerOptions = services.BuildServiceProvider().GetRequiredService<JsonSerializerOptions>();

            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = jsonSerializerOptions.PropertyNamingPolicy;    
                    });
        }
    }
    
}
