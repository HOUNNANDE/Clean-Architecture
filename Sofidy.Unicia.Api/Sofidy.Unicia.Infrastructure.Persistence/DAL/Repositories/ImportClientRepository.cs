using Sofidy.Unicia.Domain.Entities;
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
    public class ImportClientRepository : BaseRepository<UniciaImportContext, ImportClient>, IImportClientRepository
    { 
        public ImportClientRepository(UniciaImportContext context) : base(context)
        {
        } 
     }
}
