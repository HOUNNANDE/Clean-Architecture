using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services.Common
{
    public abstract class BaseApplicationDbContextService : BaseApplicationService
    {

        private readonly IUnitOfWorkUniciaImport? UniciaOfWorkImport;
        private readonly IUnitOfWorkUnicia? UnitOfWork; 

        public BaseApplicationDbContextService(IUnitOfWorkUniciaImport? unitOfWorkImport, 
                                      IUnitOfWorkUnicia? unitOfWork) 
        { 
            UniciaOfWorkImport = unitOfWorkImport;
            UnitOfWork = unitOfWork;
        }

        public BaseApplicationDbContextService(IUnitOfWorkUniciaImport unitOfWorkImport) : this(unitOfWorkImport, null) { }
        public BaseApplicationDbContextService(IUnitOfWorkUnicia unitOfWork) : this(null, unitOfWork) { }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if(UniciaOfWorkImport != null)
                await UniciaOfWorkImport.SaveChanges(cancellationToken);

            if (UnitOfWork != null)
                await UnitOfWork.SaveChanges(cancellationToken);

        }

        public void SaveChanges(CancellationToken cancellationToken = default) 
            => SaveChangesAsync(cancellationToken).Wait();
    }
}
