namespace Tickets.Domain.Abstractions
{
    /// <summary>
    /// Base class for all domain entities.
    /// 
    /// Provides support for collecting domain events
    /// raised during the lifetime of the entity.
    /// </summary>
    public abstract class Entity
    {
        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents
        => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}