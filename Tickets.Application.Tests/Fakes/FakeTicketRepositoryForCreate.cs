using Tickets.Application.Abstractions;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Tests.Fakes
{
    public sealed class FakeTicketRepositoryForCreate : ITicketRepository
    {
        public bool AddCalled { get; private set; }

        public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken)
        {
            AddCalled = true;
            await Task.CompletedTask;
        }

        public async Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
