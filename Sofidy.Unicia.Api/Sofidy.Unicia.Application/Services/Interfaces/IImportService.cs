using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Domain.Common;
using Sofidy.Unicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Services.Interfaces
{
    public interface IImportService
    { 
        ValueTask<ImportAgent> CreateImportAgent(ImportAgentDTO agent, CancellationToken cancellationToken);
        ValueTask<ImportStatusDTO> GetImportStatusByCType(string cType, decimal id, CancellationToken cancellationToken);
        ValueTask<IConvert?> GetIConvertByIdClient(string cType, string idClient);
    }
}
