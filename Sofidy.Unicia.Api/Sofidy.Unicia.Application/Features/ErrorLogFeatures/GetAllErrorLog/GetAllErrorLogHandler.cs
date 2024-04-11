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

namespace Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog
{
    public sealed record GetAllErrorLogRequest : IRequest<IEnumerable<GetAllErrorLogResponse>>
    {
    }

    public sealed class GetAllIConvertHandler : IRequestHandler<GetAllErrorLogRequest, IEnumerable<GetAllErrorLogResponse>>
    {
        private readonly IImportCommonService _importCommonService;

        private readonly IMapper _mapper;

        public GetAllIConvertHandler(IImportCommonService importCommonService,
                                    IMapper mapper)
        {
            _importCommonService = importCommonService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllErrorLogResponse>> Handle(GetAllErrorLogRequest request, CancellationToken cancellationToken)
        {
            var errorLogs = await _importCommonService.GetAllImportErrorLog(cancellationToken);

            var response = _mapper.Map<IEnumerable<GetAllErrorLogResponse>>(errorLogs);

            return response;
        }
    }
}
