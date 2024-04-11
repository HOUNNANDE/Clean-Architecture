using Microsoft.AspNetCore.Mvc;
using Sofidy.Unicia.Api.Common;
using Sofidy.Unicia.Application;
using Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllIConvert;
using Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllPImport;
using Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner;
using Sofidy.Unicia.Application.Services;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Swashbuckle.Swagger.Annotations;
using System.Threading;

namespace Sofidy.Unicia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ApiController<MetadataController>
    {

        public MetadataController() : base()
        {
        }
         
        [HttpGet("IConvert", Name = $"{nameof(MetadataController)}_GetIConvert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetIConvert(CancellationToken cancellationToken)
        {
            var res = await Mediator.Send(new GetAllIConvertRequest(), cancellationToken); ;

            return Ok(res);
        }
         
        //Sofidy
        //Tikeasy
        //Projet Vunerability
        //Omycron 
        //Tache Technique (Livraison CD/CI , Deblocage Technique , TEF ) 
        //Support EDM

        /// <summary>
        /// Get All PImport
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("PImport", Name = $"{nameof(MetadataController)}_GetPImport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPImport(CancellationToken cancellationToken)
        {
            var res = await Mediator.Send(new GetAllPImportRequest(), cancellationToken); ;

            return Ok(res);
        }
    }
}