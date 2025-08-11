using Common.Contracts.Events;
using Common.Infas.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infas.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator,
            List<BaseEvent> domainEvents,
            Serilog.ILogger logger)
        {
            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);

                var eventData = new SerializeService().Seriallize(domainEvent);
                logger.Information("\n----\nA domain event has been published!\n" +
                    $"Event: {domainEvent.GetType().Name}\n" +
                    $"Data: {eventData}");
            }
        }
    }
}
