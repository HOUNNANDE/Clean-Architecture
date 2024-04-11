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
using Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllIConvert;
using Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog;

namespace Sofidy.Unicia.Application.Features.MetadataFeatures.GetAllIConvert
{
    public class GetAllIConvertRequest : IRequest<IEnumerable<GetAllIConvertResponse>>
    {
    }

    public sealed class GetAllIConvertHandler : IRequestHandler<GetAllIConvertRequest, IEnumerable<GetAllIConvertResponse>>
    {
        private readonly IImportCommonService _importCommonService; 
        private readonly IMapper _mapper;

        public GetAllIConvertHandler(IImportCommonService importCommonService, 
                                    IMapper mapper)
        {
            _importCommonService = importCommonService; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllIConvertResponse>> Handle(GetAllIConvertRequest request, CancellationToken cancellationToken)
        {
            var entities = await _importCommonService.GetAllIConvert(cancellationToken);

            var response = _mapper.Map<IEnumerable<GetAllIConvertResponse>>(entities);

            return response;
        }
    }
}