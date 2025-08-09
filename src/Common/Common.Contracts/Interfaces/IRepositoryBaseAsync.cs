﻿using Common.Contracts.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Interfaces
{
    public interface IRepositoryBaseAsync<TEntity, TKey, TContext> : IRepositoryBaseAsync<TEntity, TKey>
     where TEntity : EntityBase<TKey>
     where TContext : DbContext
    {

    }

    public interface IRepositoryBaseAsync<TEntity, TKey> : IRepositoryQueryBase<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        Task<TKey> CreateAsync(TEntity entity);

        Task<IList<TKey>> CreateListAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateListAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task DeleteListAsync(IEnumerable<TEntity> entities);

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task EndTransactionAsync();

        Task RollbackTransactionAsync();

        Task SaveChangeAsync();
    }
}
