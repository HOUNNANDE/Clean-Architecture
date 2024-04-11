using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Context
{
    public class UnitOfWorkUnicia : IUnitOfWorkUnicia
    {
        private readonly UniciaContext _context;

        public UnitOfWorkUnicia(UniciaContext context)
        {
            _context = context;
        }

        public Task SaveChanges(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
