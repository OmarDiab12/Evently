namespace Evently.Modules.Events.Domain.Abstractions;

public interface IDomainEvents
{
    Guid Id { get; }
    DateTime OccuredOnUtc { get; }
}
