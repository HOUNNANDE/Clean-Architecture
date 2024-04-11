using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Domain.Enum;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories
{
    public class IConvertRepository : BaseRepository<UniciaImportContext, IConvert>, IIConvertRepository
    {
        public IConvertRepository(UniciaImportContext context) : base(context)
        {
        }

        /// <summary>
        /// By Key 
        /// </summary>
        /// <param name="key"></param>
        public Task<List<IConvert>> Get(ITyParam iTyparam, string iClientKey)
        {
            var lstEntities = base.Get(filter: filter => ( filter.ITyparam == ((int)iTyparam) && 
                                                           filter.IClient == iClientKey));

            return lstEntities;
        }
         
    }
}
