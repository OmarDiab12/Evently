
namespace Evently.Modules.Events.Domain.Events;

public sealed partial class Event
{
    public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }
}
