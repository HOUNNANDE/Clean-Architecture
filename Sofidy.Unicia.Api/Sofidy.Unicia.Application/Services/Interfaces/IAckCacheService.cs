using Sofidy.Unicia.Application.Services.DTO.AckCacheService;
using Sofidy.Unicia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofidy.Unicia.Application.Services.Interfaces
{
    public interface IAckCacheService
    {   
        ValueTask<AckCache> Get(Guid id, CancellationToken cancellationToken);
        void LPush(AckCacheDTO ackcacheDto);
        Task<IList<AckCache>> RPop(int? maxLimit);
        Task UpdateFacked(Guid id, CancellationToken cancellationToken, bool value = true);
    }
}
