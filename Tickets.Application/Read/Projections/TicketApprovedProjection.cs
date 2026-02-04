using Tickets.Application.Abstractions;
using Tickets.Domain.Events;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Read.Projections
{
    /// <summary>
    /// Updates the read model when a ticket is approved.
    /// </summary>
    public sealed class TicketApprovedProjection
    {
        private readonly ITicketReadRepository _repository;

        public TicketApprovedProjection(ITicketReadRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(
            TicketApprovedEvent domainEvent,
            CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(
                domainEvent.TicketId,
                cancellationToken);

            if (model is null)
                return;

            model.Status = TicketStatus.Approved;

            await _repository.UpdateAsync(model, cancellationToken);
        }
    }
}