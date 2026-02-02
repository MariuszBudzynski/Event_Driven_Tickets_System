using Tickets.Application.Abstractions;

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

        public UnitOfWork(TicketsDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
