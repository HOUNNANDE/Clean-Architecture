using AutoMapper;
using MediatR;
using Sofidy.Unicia.Application.Common.Exceptions;
using Sofidy.Unicia.Application.Services.Common;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Common;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Domain.Entities.Abstract;
using Sofidy.Unicia.Domain.Enum;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context.Interfaces; 
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Services
{
    internal class ImportService : BaseApplicationDbContextService, IImportService
    {
        private readonly IImportAgentRepository _importAgentRepository;
        private readonly IIConvertRepository _iconvertRepository;
        private readonly IImportCommonService _importCommonService;
        private readonly IMapper _mapper;

        public ImportService(IUnitOfWorkUniciaImport unitOfWork,
                             IImportCommonService importCommonService,
                             IImportAgentRepository importAgentRepository,
                             IIConvertRepository iconvertRepository,
                             IMapper mapper) : base(unitOfWork)
        {
            _importAgentRepository = importAgentRepository; 
            _iconvertRepository = iconvertRepository;
            _importCommonService = importCommonService;
            _mapper = mapper;
        }  

        public async ValueTask<ImportAgent> CreateImportAgent(ImportAgentDTO importagentDto, CancellationToken cancellationToken)
        {
            var importAgent = _mapper.Map<ImportAgent>(importagentDto);

            importAgent = await _importCommonService.AsModifiableEntity(importAgent, importagentDto.Id);

            _importAgentRepository.Create(importAgent);

            await SaveChangesAsync();

            return importAgent;
        }

        public async ValueTask<IConvert?> GetIConvertByIdClient(string cType, string idClient)
        {
            var iTyParam = DomainConstants.GetITyPramByEntity(cType);

            if (iTyParam.Equals(default))
                throw new OperationArgumentNullException($"ITyParam : {cType}");

            var entity = await _iconvertRepository.Get(filter: obj => obj.ITyparam == (decimal)iTyParam && obj.IClient == idClient);

            return entity.FirstOrDefault();
        }

        public async ValueTask<ImportStatusDTO> GetImportStatusByCType(string cType, decimal id, CancellationToken cancellationToken)
        {
            var repository = MapRepository(cType);
            var entity = await repository.GetById(new object[] { id }, cancellationToken);

            if (entity == null)
                throw new OperationArgumentNullException($"BaseImportEntity:{cType} {id}");
             
            var dto = _mapper.Map<ImportStatusDTO>(entity);

            return dto;
        }

        private dynamic MapRepository(string cType)
        {
            switch (cType)
            {
                case nameof(ImportAgent):
                    return _importAgentRepository;
                default:
                    throw new OperationArgumentNullException($"Repository {cType}");
            }
        }

    }
}
