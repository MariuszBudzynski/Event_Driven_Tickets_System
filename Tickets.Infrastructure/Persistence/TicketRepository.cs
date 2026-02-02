using Microsoft.EntityFrameworkCore;
using Tickets.Application.Abstractions;
using Tickets.Domain.Tickets;

namespace Tickets.Infrastructure.Persistence
{
    public sealed class TicketRepository : ITicketRepository
    {
        private readonly TicketsDbContext _context;

        public TicketRepository(TicketsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken)
        {
            await _context.Tickets.AddAsync(ticket, cancellationToken);
        }

        public async Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }
    }
}
