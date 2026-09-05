
using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events;

public sealed partial class Event
{
    public abstract class DomainEvent : IDomainEvents
    {
        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccuredOnUtc = DateTime.UtcNow;
        }

        protected DomainEvent(Guid id, DateTime occuredOnUtc)
        {
            Id = id;
            OccuredOnUtc = occuredOnUtc;
        }
        public Guid Id { get; init; }

        public DateTime OccuredOnUtc { get; init; }

    }
}
