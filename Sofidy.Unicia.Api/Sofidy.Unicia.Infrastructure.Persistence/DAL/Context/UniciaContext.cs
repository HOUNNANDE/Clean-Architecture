using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Context
{
    public class UniciaContext : DbContext
    {
        public UniciaContext(DbContextOptions<UniciaContext> options) : base(options) { }
    }
}
