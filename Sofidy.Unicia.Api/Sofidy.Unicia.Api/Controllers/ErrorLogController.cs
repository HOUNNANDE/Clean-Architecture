using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofidy.Unicia.Api.Common;
using Sofidy.Unicia.Application;
using Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog;
using Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner;
using Sofidy.Unicia.Application.Services;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using System.Threading;

namespace Sofidy.Unicia.Api.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class ErrorLogController : ApiController<ErrorLogController>
    { 
        public ErrorLogController() : base()
        {
        }


        [HttpGet(Name = $"{nameof(ErrorLogController)}_Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var res = await Mediator.Send(new GetAllErrorLogRequest(), cancellationToken); ;

            return Ok(res);
        } 
    }
}