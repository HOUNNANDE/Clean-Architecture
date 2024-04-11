using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofidy.Unicia.Api.Controllers;

namespace Sofidy.Unicia.Api.Common
{
    public class ApiController<T>: ControllerBase
    {
        private readonly ILogger<T> _logger;
        private readonly IMediator _mediator;

        public IServiceProvider ServiceProvider
        {
            get
            {
                return HttpContext.RequestServices;
            }
        }
        
        public ILogger<T> Logger { get { return ServiceProvider.GetRequiredService<ILogger<T>>(); } }
        public IMediator Mediator { get { return ServiceProvider.GetRequiredService<IMediator>(); } }

        public ApiController()
        { 
        }
    }
}
