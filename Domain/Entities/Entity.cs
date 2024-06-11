using Domain.Interface;
using Events.Interface;

namespace Domain;

public abstract class Entity : IHasDomainEvent
{
    private readonly List<IEvent> _domainEvents = new();

    public List<IEvent> DomainEvents => _domainEvents;
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    
}