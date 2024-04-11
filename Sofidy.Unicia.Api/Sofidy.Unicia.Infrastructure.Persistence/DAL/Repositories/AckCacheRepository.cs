using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Common;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories
{
    public class AckCacheRepository : BaseRepository<UniciaImportContext, AckCache>, IAckCacheRepository
    {   
        public AckCacheRepository(UniciaImportContext context) : base(context)
        {
            
        }

     
    }
}
