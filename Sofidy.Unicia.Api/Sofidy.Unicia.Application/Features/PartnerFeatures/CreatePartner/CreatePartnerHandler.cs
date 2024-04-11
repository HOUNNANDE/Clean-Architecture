using AutoMapper;
using MediatR;
using Sofidy.Unicia.Application.Common.Exceptions;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Sofidy.Unicia.Application.Services;
using Sofidy.Unicia.Application.Services.DTO.AckCacheService;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Features.PartnerFeatures.CreatePartner
{
    public sealed class CreatePartnerHandler : IRequestHandler<CreatePartnerRequest, CreatePartnerResponse>
    {
        private readonly IImportService _importService; 
        private readonly IAckCacheService _ackService;
        private readonly IMapper _mapper;

        public CreatePartnerHandler(IImportService importService, 
                                    IAckCacheService ackService , 
                                    IMapper mapper)
        {
            _importService = importService;
            _ackService = ackService;
            _mapper = mapper;
        }

        public async Task<CreatePartnerResponse> Handle(CreatePartnerRequest request, CancellationToken cancellationToken)
        {
            // Create ImportAgent
            var importAgentDto = _mapper.Map<ImportAgentDTO>(request);
            var importAgentEntity = await _importService.CreateImportAgent(importAgentDto, cancellationToken);

            // Create AckCache
            var ackCacheDTO = _mapper.Map<AckCacheDTO>(importAgentDto);
            ackCacheDTO = ackCacheDTO with
            {
                IdImport = importAgentEntity.IdImportAgents,
                Channel = request.Channel,
                Type = nameof(ImportAgent)
            };

            _ackService.LPush(ackCacheDTO);

            return default;
        } 
    }
}
