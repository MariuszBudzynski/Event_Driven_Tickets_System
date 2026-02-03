using Tickets.Domain.Abstractions;

namespace Tickets.Application.Abstractions
{
    /// <summary>
    /// Dispatches domain events raised by aggregates.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(
        IReadOnlyCollection<DomainEvent> domainEvents,
        CancellationToken cancellationToken);
    }
}