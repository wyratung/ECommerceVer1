using Common.Contracts.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Interfaces
{
    public interface IRepositoryQueryBase<TEntity, TKey, TContext> : IRepositoryQueryBase<TEntity, TKey>
    where TEntity : EntityBase<TKey>
    where TContext : DbContext
    {

    }

    public interface IRepositoryQueryBase<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        IQueryable<TEntity> FindAll(bool trackChanges = false);

        IQueryable<TEntity> FindAll(bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false);

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity?> GetByIdAsync(TKey id);

        Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
