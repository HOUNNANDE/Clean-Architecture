using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Domain.Enum;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces
{
    public interface IIConvertRepository : IBaseRepository<UniciaImportContext, IConvert>
    {
        Task<List<IConvert>> Get(ITyParam iTyparam, string iClientKey);
    }
}
