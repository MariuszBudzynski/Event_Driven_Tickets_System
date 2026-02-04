using Tickets.Application.Abstractions;
using Tickets.Domain.Abstractions;

namespace Tickets.Infrastructure.Persistence
{
    /// <summary>
    /// Entity Framework based Unit of Work.
    /// 
    /// Ensures that all changes are persisted atomically.
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TicketsDbContext _context;
        private readonly IDomainEventDispatcher _dispatcher;

        public UnitOfWork(TicketsDbContext context, IDomainEventDispatcher dispatcher)
        {
            _context = context;
            _dispatcher = dispatcher;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);

            var domainEvents = _context.ChangeTracker
                .Entries<Entity>()
                .SelectMany(e => e.Entity.DomainEvents)
                .ToList();

            foreach (var entry in _context.ChangeTracker.Entries<Entity>())
            {
                entry.Entity.ClearDomainEvents();
            }

            await _dispatcher.DispatchAsync(domainEvents, cancellationToken);
        }
    }
}