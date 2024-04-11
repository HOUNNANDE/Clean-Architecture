
using Sofidy.Unicia.Api.Common;
using Sofidy.Unicia.Api.Extensions;
using Sofidy.Unicia.Infrastructure.Extensions;

namespace Sofidy.Unicia.Api
{
    public class Program
    {
        // Serilog File Option  OK 
        // Serilog Splunk Option  OK

        // Swagger 2.0 Option OK 
        // Swagger Yaml Option OK

        // IOC DI OK
        // IOC DI Repository OK 
        // IOC DI Service OK 

        // Business Logic Service OK

        // Entity Framework OK 
        // CRUD OK 
        // Entity OK 
        // UnitOfWork OK 
        // Transaction 

        // Fulent Validation OK
        // Mapper OK
        // Mvc OK
        // Cache Redis
        // GED
        // Notification
        // Email
        // Teams
        // Salesforce Settion OK
        // Salesforce Service NetCoreForce  OK

        // - Bus Service - Queue Option
        // Test Plan - NUnit 
        // Devops 
        // Docker OK

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services; 

            builder.Host.UseAppSettings();

            services.AddJsonOptions();

            // Swagger
            services.ConfigureSwagger(); 

            // Scoped Service
            services.ConfigureServices(builder.Configuration);

            // Controller
            services.AddMVCControllers();

            // CORS 
            services.ConfigureCorsPolicy();

            // Logger
            builder.Logging.ClearProviders();
            builder.Host.UseLoggingSetup(builder.Configuration, builder.Environment);


            #region Use 
            var app = builder.Build();

            //app.UseMiddleware<ExceptionHandlerMiddleware>();
               
            app.UseSwaggerSetup(builder.Environment);   
               
            app.UseHttpsRedirection()
               .UseAuthorization();

            app.UseErrorHandler();
            #endregion

            app.MapControllers(); 

            await app.RunAsync();
        }
    }
}