using System.Collections.ObjectModel;

namespace Foodstagram.Domain.Common;

public abstract class AggregateRoot : EntityBase
{
    private readonly List<DomainEvent> _domainEvents = new();

    public IReadOnlyCollection<DomainEvent> DomainEvents =>
        new ReadOnlyCollection<DomainEvent>(_domainEvents);

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
