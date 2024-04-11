using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces
{
    public interface IImportAgentRepository: IBaseRepository<UniciaImportContext, ImportAgent>
    { 
    }
}
