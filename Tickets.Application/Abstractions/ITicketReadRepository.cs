using Tickets.Application.Read.Models;

namespace Tickets.Application.Abstractions
{
    /// <summary>
    /// Repository for ticket read models.
    /// </summary>
    public interface ITicketReadRepository
    {
        Task<TicketReadModel?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

        Task AddAsync(
            TicketReadModel model,
            CancellationToken cancellationToken);

        Task UpdateAsync(
            TicketReadModel model,
            CancellationToken cancellationToken);
    }
}