using Sofidy.Unicia.Application.Features.ErrorLogFeatures.GetAllErrorLog;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Domain.Entities.Abstract;
using Sofidy.Unicia.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Services.Interfaces
{
    public interface IImportCommonService
    {
        /// <summary>
        /// Find refrence key in IConvert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="iClient"></param>
        /// <returns></returns>
        ValueTask<T> AsModifiableEntity<T>(T entity, string iClient) where T : BaseImportEntity;
        Task<IEnumerable<IConvert>> GetAllIConvert(CancellationToken cancellationToken);
        Task<IEnumerable<PImport>> GetAllPImport(CancellationToken cancellationToken);
        Task<IEnumerable<ImportErrorLog>> GetAllImportErrorLog(CancellationToken cancellationToken);
    }
}
