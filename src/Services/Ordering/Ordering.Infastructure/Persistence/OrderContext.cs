using Common.Contracts.Events;
using Common.Contracts.Interfaces;
using Common.Infas.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Serilog;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Persistence
{
    public class OrderContext : DbContext
    {
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;

        public OrderContext(DbContextOptions<OrderContext> options, IMediator mediator, Serilog.ILogger logger) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntryEntites = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified
                        || e.State == EntityState.Added
                        || e.State == EntityState.Deleted);

            foreach (var item in modifiedEntryEntites)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        if (item.Entity is IDateTracking addedEntity)
                        {
                            addedEntity.CreatedDate = DateTimeOffset.UtcNow;
                            //item.State = EntityState.Added;
                        }
                        break;

                    case EntityState.Modified:
                        Entry(item.Entity).Property("Id").IsModified = false;
                        if (item.Entity is IDateTracking modifiedEntity)
                        {
                            modifiedEntity.LastModifiedDate = DateTimeOffset.UtcNow;
                            //item.State = EntityState.Modified;
                        }
                        break;
                }
            }

            SetBaseEventsBeforeSaveChanges();

            var result = await base.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(_baseEvents, _logger);
            return result;
        }

        private List<BaseEvent> _baseEvents = [];
        private void SetBaseEventsBeforeSaveChanges()
        {
            // Get all of entity implement interface IEventEntity
            var domainEntities = ChangeTracker.Entries<IEventEntity>()
                .Select(e => e.Entity)
                .Where(x => x.DomainEvents().Any())
                .ToList();

            // Get all of domain events
            var domainEvents = domainEntities
                .SelectMany(x => x.DomainEvents())
                .ToList();

            _baseEvents.AddRange(domainEvents);

            foreach (var domainEntity in domainEntities)
            {
                domainEntity.ClearDomainEvent();
            }
        }
    }
}
