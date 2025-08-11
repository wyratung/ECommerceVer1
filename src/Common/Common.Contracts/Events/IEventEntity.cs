using Common.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Events
{
    public interface IEventEntity
    {
        void AddDomainEvent(BaseEvent domainEvent);

        void RemoveDomainEvent(BaseEvent domainEvent);

        void ClearDomainEvent();

        IReadOnlyCollection<BaseEvent> DomainEvents();
    }

    public interface IEventEntity<T> : IEntityBase<T>, IEventEntity
    {

    }
}
