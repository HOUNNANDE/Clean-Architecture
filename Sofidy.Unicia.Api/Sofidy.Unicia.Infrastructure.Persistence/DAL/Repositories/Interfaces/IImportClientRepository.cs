using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces
{
    public interface IImportClientRepository: IBaseRepository<UniciaImportContext, ImportClient>
    {
    }
}
