using Sofidy.Unicia.Application.Services.Common;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Common;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Domain.Entities.Abstract;
using Sofidy.Unicia.Domain.Enum;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context.Interfaces;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories;
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
    internal class ImportCommonService : BaseApplicationDbContextService, IImportCommonService
    {
        private readonly IIConvertRepository _iconvertRepository;
        private readonly IImportErrorLogRepository _importErrorLogRepository;
        private readonly IPImportRepository _pimportRepository;

        public ImportCommonService(IUnitOfWorkUniciaImport unitOfWork,
                                   IImportErrorLogRepository importErrorLogRepository, 
                                   IPImportRepository pimportRepository,
                                   IIConvertRepository iconvertRepository) : base(unitOfWork)
        {
            _iconvertRepository = iconvertRepository;
            _pimportRepository = pimportRepository;
            _importErrorLogRepository = importErrorLogRepository;
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="importAgent"></param>
        /// <param name="iTyparam"></param>
        /// <param name="iClient"></param>
        /// <returns></returns>
        public async ValueTask<T> AsModifiableEntity<T>(T entity, string iClient) where T: BaseImportEntity
        {
            const string CStatut_Modifiable = "M";
            const string CStatut_Creatable = "N";

            //var kv = DomainConstants.Mapping_Entity_IConvertITyParam.First(p => p.Key == typeof(T).Name);
            var value = DomainConstants.GetITyPramByEntity<T>();

            var lstEntities = await _iconvertRepository.Get(value, iClient);

            if (lstEntities.Any())
            {
                entity = entity with { CStatut = lstEntities.Any() ? CStatut_Modifiable : CStatut_Creatable };
            }
            return entity;
        }

        public async Task<IEnumerable<IConvert>> GetAllIConvert(CancellationToken cancellationToken)
            => await _iconvertRepository.GetAll(cancellationToken);

        public async Task<IEnumerable<PImport>> GetAllPImport(CancellationToken cancellationToken)
            => await _pimportRepository.GetAll(cancellationToken);

        public async Task<IEnumerable<ImportErrorLog>> GetAllImportErrorLog(CancellationToken cancellationToken) 
            => await _importErrorLogRepository.GetAll(cancellationToken);
         
    }
}
