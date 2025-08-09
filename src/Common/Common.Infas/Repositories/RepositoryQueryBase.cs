using Common.Contracts.Domains;
using Common.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infas.Repositories
{
    public class RepositoryQueryBase<TEntity, TKey, TContext> : IRepositoryQueryBase<TEntity, TKey, TContext>
    where TEntity : EntityBase<TKey>
    where TContext : DbContext
    {
        private readonly TContext _dbContext;
        public RepositoryQueryBase(TContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            _dbContext = dbContext;
        }

        #region Query Operations
        public IQueryable<TEntity> FindAll(bool trackChanges = false)
        {
            if (trackChanges)
            {
                return _dbContext.Set<TEntity>();
            }
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> FindAll(bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var items = FindAll(trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return items;
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false)
        {
            if (trackChanges)
            {
                return _dbContext.Set<TEntity>().Where(expression);
            }
            return _dbContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var items = FindByCondition(expression, trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return items;
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await FindByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges: false, includeProperties)
                .FirstOrDefaultAsync();
        }
        #endregion
    }
}
