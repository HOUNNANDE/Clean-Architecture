using AutoMapper;
using MediatR;
using Sofidy.Unicia.Application.Services.Common;
using Sofidy.Unicia.Application.Services.DTO.AckCacheService;
using Sofidy.Unicia.Application.Services.DTO.ImportService;
using Sofidy.Unicia.Application.Services.Interfaces;
using Sofidy.Unicia.Domain.Entities;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Context.Interfaces;
using Sofidy.Unicia.Infrastructure.Persistence.DAL.Repositories.Interfaces;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Application.Services
{
    internal class AckCacheServices : BaseApplicationDbContextService, IAckCacheService
    { 
        private readonly IAckCacheRepository _ackCacheRepository;
        private readonly IMapper _mapper;

        public AckCacheServices(IUnitOfWorkUniciaImport unitOfWork,
                                IAckCacheRepository ackCacheRepository,
                                IMapper mapper) : base(unitOfWork)
        {
            _ackCacheRepository = ackCacheRepository;
            _mapper = mapper;
        }

        public void LPush(AckCacheDTO ackcacheDto)
        {
            var ackcache = _mapper.Map<AckCache>(ackcacheDto);
            _ackCacheRepository.Create(ackcache);

            SaveChanges();
        }

        public async Task<IList<AckCache>> RPop(int? maxLimit)
        {
            List<AckCache> lstAckCache = await _ackCacheRepository.Get(filter: filter => !filter.FAcked,
                                                                       orderBy: sort => sort.OrderBy(m => m.DCreated),
                                                                       count: maxLimit);

            return (IList<AckCache>)lstAckCache;
        }  

        public async ValueTask<AckCache?> Get(Guid id, CancellationToken cancellationToken)
            => await _ackCacheRepository.GetById(new object[] { id }, cancellationToken);

        public async Task UpdateFacked(Guid id, CancellationToken cancellationToken, bool value = true)
        {
            var entity = await _ackCacheRepository.GetById(new object[] { id }, cancellationToken);

            if(entity != null)
            {
                entity.FAcked = value;
                await SaveChangesAsync();
            } 
        }
    }
}
