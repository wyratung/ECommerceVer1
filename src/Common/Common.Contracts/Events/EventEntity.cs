using Common.Contracts.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Events
{
    public class EventEntity<T> : EntityBase<T>, IEventEntity<T>
    {
        private readonly List<BaseEvent> _domainEvents = new();

        public void AddDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void RemoveDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvent()
        {
            _domainEvents.Clear();
        }

        public IReadOnlyCollection<BaseEvent> DomainEvents() => _domainEvents.AsReadOnly();
    }
}
