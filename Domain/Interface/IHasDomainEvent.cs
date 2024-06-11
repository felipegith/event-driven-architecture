using Events.Interface;

namespace Domain.Interface;

public interface IHasDomainEvent
{
    public List<IEvent> DomainEvents { get; }

    public void ClearDomainEvents();
}