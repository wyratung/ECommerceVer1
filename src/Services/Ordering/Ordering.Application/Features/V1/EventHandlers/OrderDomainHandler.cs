using MediatR;
using Ordering.Domain;
using Ordering.Domain.NewFolder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.V1.EventHandlers
{
    public class OrderDomainHandler :
    INotificationHandler<OrderCreatedEvent>,
    INotificationHandler<OrderDeletedEvent>

    {
        private readonly ILogger _logger;

        public OrderDomainHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Complete domain logic here
            _logger.Information("Ordering domain event: {domainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }

        public Task Handle(OrderDeletedEvent notification, CancellationToken cancellationToken)
        {
            // Complete domain logic here
            _logger.Information("Ordering domain event: {domainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
