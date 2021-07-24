using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.DomainObjects
{
    public abstract class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
