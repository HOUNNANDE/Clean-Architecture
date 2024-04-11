using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Context.Interfaces
{
    public interface IUnitOfWorkUnicia
    {
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
