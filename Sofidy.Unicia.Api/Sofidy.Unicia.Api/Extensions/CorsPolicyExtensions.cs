using System.Runtime.CompilerServices;

namespace Sofidy.Unicia.Api.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static IServiceCollection ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            return services;
        }
    }
}
