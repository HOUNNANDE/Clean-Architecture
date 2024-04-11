using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sofidy.Unicia.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Unicia.Model.Models;

namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Common
{
    public interface IBaseRepository<C, T> where T : BaseEntity
    {
        void Create(T entity);
        ValueTask<EntityEntry<T>> CreateAsync(T entity);
        void Update(T entity);
        ValueTask<EntityEntry<T>> UpdateAsync(T entity);
        void Delete(T entity);
        ValueTask<EntityEntry<T>> DeleteAsync(T entity);
        ValueTask<T?> GetById(object?[]? keyValues, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        Task<List<T>> Get(Expression<Func<T, bool>>? filter = default,
                                          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = default,
                                          IEnumerable<string>? includeProperties = default,
                                          int? count = null);

        IEnumerator<T> GetEnumerator(Expression<Func<T, bool>>? filter = default,
                                          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = default,
                                          IEnumerable<string>? includeProperties = default,
                                          int? count = null);
    }
}
