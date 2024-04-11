using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sofidy.Unicia.Domain.Entities.Abstract;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Unicia.Model.Models;


namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Common
{
    public class BaseRepository<C, T> : IBaseRepository<C, T> where C : DbContext
                                                             where T : BaseEntity
    {
        protected const int QUERY_LIMIT = 100000;
        protected readonly C _context;
        internal DbSet<T> _dbSet;
        public BaseRepository(C context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public ValueTask<EntityEntry<T>> CreateAsync(T entity)
        {
            return _dbSet.AddAsync(entity);
        } 

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }  
        public ValueTask<EntityEntry<T>> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        } 

        public ValueTask<EntityEntry<T>> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        } 

        public ValueTask<T?> GetById(object?[]? keyValues, CancellationToken cancellationToken)
        {
            return _dbSet.FindAsync(keyValues, cancellationToken);
        } 

        public virtual Task<List<T>> Get(Expression<Func<T, bool>>? filter = default,
                                          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = default,
                                          IEnumerable<string>? includeProperties = default,
                                          int? count = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (string property in includeProperties)
                {
                    query.Include(property);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Take(count ?? QUERY_LIMIT);

            return query.ToListAsync();
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return _dbSet.ToListAsync(cancellationToken);
        } 

        public IEnumerator<T> GetEnumerator(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, IEnumerable<string>? includeProperties = null, int? count = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (string property in includeProperties)
                {
                    query.Include(property);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Take(count ?? QUERY_LIMIT);

            return query.GetEnumerator();
        }
    }
}
