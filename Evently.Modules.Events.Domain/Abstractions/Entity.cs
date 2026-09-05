namespace Evently.Modules.Events.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvents> _domainEvents = [];
    protected Entity() { }

    public IReadOnlyCollection<IDomainEvents> DomainEvents => _domainEvents.ToList();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(IDomainEvents domainEvents)
    {
        _domainEvents.Add(domainEvents);
    }
}
