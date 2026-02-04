using Tickets.Application.Abstractions;
using Tickets.Domain.Events;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Read.Projections
{
    /// <summary>
    /// Updates ticket read model when a ticket is submitted.
    /// </summary>
    public sealed class TicketSubmittedProjection
    {
        private readonly ITicketReadRepository _repository;
        public TicketSubmittedProjection(ITicketReadRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(
           TicketSubmittedEvent domainEvent,
           CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(
                domainEvent.TicketId,
                cancellationToken);

            if (model is null)
                return;

            model.Status = TicketStatus.Submitted;

            await _repository.UpdateAsync(model, cancellationToken);
        }
    }
}