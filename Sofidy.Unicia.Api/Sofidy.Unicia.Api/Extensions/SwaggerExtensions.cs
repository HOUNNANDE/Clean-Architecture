using Microsoft.Extensions.Options;
using Sofidy.Unicia.Api.Configurations.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Sofidy.Unicia.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {  
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

           

            return services;
        }

        public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            var provider = app.ApplicationServices; 
            var option = provider.GetRequiredService<IOptions<SwaggerOption>>().Value;   

            if (environment.IsDevelopment() || option.UseSwagger)
            {
                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = option.SerializeAsV2; 
                });

                app.UseSwaggerUI(c =>
                {
                    foreach(var endpoint in option.SwaggerUI.Endpoints)
                    {
                        c.SwaggerEndpoint(endpoint.Url, endpoint.Name);
                    } 
                });
            } 

            return app;
        }
    }
}
