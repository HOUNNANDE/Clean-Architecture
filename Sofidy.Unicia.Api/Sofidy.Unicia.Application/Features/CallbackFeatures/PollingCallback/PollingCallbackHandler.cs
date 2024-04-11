using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using RestSharp;
using Sofidy.Unicia.Application.Features.CallbackFeatures.PostCallback;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Common;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Configurations.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Features.CallbackFeatures.PollingCallback
{
    public record PollingCallbackRequest : IRequest<PollingCallbackResponse>, IBaseRequest
    {
        public int? Size { get; set; } 
    }

    internal record PollingCallbackHandler : IRequestHandler<PollingCallbackRequest, PollingCallbackResponse>
    {
        private readonly IImportService _importService;
        private readonly IAckCacheService _ackService;
        private readonly IMapper _mapper;
        private readonly PollingCallbackOption _pollingCallbackOption;

        public PollingCallbackHandler(
          IImportService importService,
          IAckCacheService ackService,
          IMapper mapper,
          IOptions<PollingCallbackOption> pollingCallbackOption)
        {
            this._importService = importService;
            this._ackService = ackService;
            this._mapper = mapper;
            this._pollingCallbackOption = pollingCallbackOption?.Value ?? throw new ArgumentNullException("ollingCallback Option is null or empty");
        }

        public async Task<PollingCallbackResponse> Handle(PollingCallbackRequest request,CancellationToken cancellationToken)
        {
            IList<AckCache> lstAckCache = await this._ackService.RPop(request.Size);
             
            using RestClient _client = new RestClient(this._pollingCallbackOption.Host);
            foreach (AckCache ackCache in lstAckCache)
            { 
                ImportStatusDTO importStatusDto = await _importService.GetImportStatusByCType(ackCache.CTypes, ackCache.IdImport, cancellationToken);

                if (importStatusDto.Status == ImportStatus.None || !importStatusDto.IdBatch.HasValue)
                    break;

                var apiRequest = new RestRequest(_pollingCallbackOption.Endpoints.Callback, Method.Post);
                apiRequest.AddBody(new PostCallbackRequest() { Id = ackCache.IdAckCache });
                var apiResponse = await _client.ExecutePostAsync(apiRequest); 
            }

            PollingCallbackResponse reponse = new PollingCallbackResponse();
            return reponse;
        }
    }
}
