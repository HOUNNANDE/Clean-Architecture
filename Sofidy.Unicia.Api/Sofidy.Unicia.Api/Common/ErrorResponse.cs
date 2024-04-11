using Microsoft.Net.Http.Headers;
using Sofidy.Unicia.Application.Common.Exceptions;
using System.Net;
using System.Text.Json.Serialization;

namespace Sofidy.Unicia.Api.Common
{
    public record ErrorResponse
    {
        private Exception _exception { get; set; }

        public ErrorResponse(Exception exception) 
        {
            _exception = exception;
            // Splunk Error Code 
            Help = $"https://track.tikehaucapital.com/splunk/exceptions/{1000}";
        }
         
        public int StatusCode { 
            get
            {
                var statusCode = _exception switch
                {
                    BadRequestException => (int)HttpStatusCode.BadRequest,
                    OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                    OperationArgumentNullException => (int)HttpStatusCode.BadRequest,
                    Exception => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                return statusCode;
            }
        }

        public string[]? Errors { 
            get 
            {
                switch (_exception)
                {
                    case BadRequestException _:
                        return ((BadRequestException)_exception).Errors;
                    default:
                        return null;
                }
            }
        }

        public string Message 
        {
            get
            {
                return _exception.GetBaseException().Message;
            }
        }

        public string Help { get; set; }
    }
}
