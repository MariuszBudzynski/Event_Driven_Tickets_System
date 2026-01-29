using Tickets.Application.Abstractions;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Tests.Fakes
{
    public sealed class FakeTicketRepositoryForExistingTicket : ITicketRepository
    {
        private readonly Ticket _ticket;
        public bool GetByIdCalled { get; private set; }

        public FakeTicketRepositoryForExistingTicket(Ticket ticket)
        {
            _ticket = ticket;
        }

        public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public async Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            GetByIdCalled = true;
            return await Task.FromResult(_ticket);
        }
    }
}
