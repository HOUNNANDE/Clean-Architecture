using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofidy.Unicia.Api.Common;
using Sofidy.Unicia.Application;
using Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner;
using Sofidy.Unicia.Application.Services;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using System.Threading;

namespace Sofidy.Unicia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartnerController : ApiController<PartnerController>
    {

        public PartnerController() : base()
        {
        }

        /// <summary>
        /// Create Partner
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = $"{nameof(PartnerController)}_Post")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreatePartnerRequest request, CancellationToken cancellationToken)
        {
            await Mediator.Send(request, cancellationToken);

            return Accepted();
        } 
    }
}