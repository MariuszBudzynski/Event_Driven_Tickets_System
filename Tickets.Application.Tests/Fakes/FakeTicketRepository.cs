using Tickets.Application.Abstractions;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Tests.Fakes
{
    public class FakeTicketRepository : ITicketRepository
    {
        private readonly Ticket? _ticket;
        public FakeTicketRepository(Ticket? ticket)
        {
            _ticket = ticket;
        }
        public Task AddAsync(Ticket ticket, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public  Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ticket);
        }
    }
}
