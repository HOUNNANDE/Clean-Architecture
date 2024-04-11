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

namespace Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllPImport
{
    public sealed record GetAllPImportRequest : IRequest<IEnumerable<GetAllPImportResponse>>
    {
    }

    public sealed class GetAllPImportHandler : IRequestHandler<GetAllPImportRequest, IEnumerable<GetAllPImportResponse>>
    {
        private readonly IImportCommonService _importCommonService;
        private readonly IMapper _mapper;

        public GetAllPImportHandler(IImportCommonService importCommonService,
                                    IMapper mapper)
        {
            _importCommonService = importCommonService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllPImportResponse>> Handle(GetAllPImportRequest request, CancellationToken cancellationToken)
        {
            var entities = await _importCommonService.GetAllPImport(cancellationToken);

            var response = _mapper.Map<IEnumerable<GetAllPImportResponse>>(entities);

            return response;
        }
    }
}
