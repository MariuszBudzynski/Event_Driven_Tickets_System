using Tickets.Application.Abstractions;
using Tickets.Domain.Abstractions;

namespace Tickets.Infrastructure.Messaging
{
    /// <summary>
    /// No-op implementation of domain event dispatcher.
    /// 
    /// Used as a placeholder until a real event bus
    /// or outbox-based dispatcher is introduced.
    /// </summary>
    public sealed class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task DispatchAsync(IReadOnlyCollection<DomainEvent> domainEvents, CancellationToken cancellationToken)
        {
            // intentionally left blank
            return Task.CompletedTask;
        }
    }
}
