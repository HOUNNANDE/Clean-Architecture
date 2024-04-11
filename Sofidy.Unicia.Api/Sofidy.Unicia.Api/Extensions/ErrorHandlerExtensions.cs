using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Sofidy.Unicia.Api.Common;
using Sofidy.Unicia.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace Sofidy.Unicia.Api.Extensions
{
    public static class ErrorHandlerExtensions
    { 
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(onError);
        }

        private static void onError(IApplicationBuilder app)
        {
            var jsonSerializerOptions = app.ApplicationServices.GetRequiredService<JsonSerializerOptions>();

            app.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;

                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json"; 

                var response = new ErrorResponse(contextFeature.Error.GetBaseException()); 
                
                await context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonSerializerOptions));
            }); 
        }
    }
}
