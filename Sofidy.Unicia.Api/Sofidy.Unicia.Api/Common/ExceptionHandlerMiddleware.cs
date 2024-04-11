using System.Net;

namespace Sofidy.Unicia.Api.Common
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                //var exception = ex.Demystify();
                //_logger.LogError(exception, "An error ocurred: {Message}", exception.Message);
                //HttpStatusCode code;
                //switch (exception)
                //{
                //    default:
                //        code = HttpStatusCode.InternalServerError;
                //        break;
                //}

                //context.Response.ContentType = "application/json";
                //context.Response.StatusCode = (int)code;
                //var result = Result.Error(exception.ToStringDemystified());
                await context.Response.WriteAsJsonAsync(new Object() { }); //result);
            }
            //throw new NotImplementedException();
        }
    }
}
