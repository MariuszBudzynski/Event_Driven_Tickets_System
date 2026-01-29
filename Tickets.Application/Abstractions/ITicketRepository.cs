using Tickets.Domain.Tickets;

namespace Tickets.Application.Abstractions
{
    /// <summary>
    /// Defines a contract for accessing and persisting ticket aggregates.
    /// 
    /// This abstraction decouples the application layer from
    /// any specific persistence technology.
    /// </summary>
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Ticket ticket, CancellationToken cancellationToken);
    }
}
