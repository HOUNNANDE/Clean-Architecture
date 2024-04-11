using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofidy.Unicia.Api.Common;
using Sofidy.Unicia.Application.Features.CallbackFeatures.PostCallback;
using Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner;
using Sofidy.Unicia.Infrastructure.Client.SalesforceClient;

namespace Sofidy.Unicia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallbackController : ApiController<CallbackController>
    {
        public CallbackController() : base()
        {
            
        }

        ///// <summary>
        ///// Create Partner
        ///// </summary>
        ///// <param name="request"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //[HttpPost(Name = $"{nameof(PartnerController)}_Post")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Post(CreatePartnerRequest request, CancellationToken cancellationToken)
        //{

        //}

        /// <summary>
        /// Callback 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost(Name = $"{nameof(CallbackController)}_Post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(PostCallbackRequest request, CancellationToken cancellationToken)
        {
            await Mediator.Send(request, cancellationToken);

            return Accepted(); 
        }
    }
}
