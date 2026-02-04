using Tickets.Application.Abstractions;
using Tickets.Domain.Events;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Read.Projections
{
    public sealed class TicketRejectedProjection
    {
        private readonly ITicketReadRepository _repository;

        public TicketRejectedProjection(ITicketReadRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(
            TicketRejectedEvent domainEvent,
            CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(
                domainEvent.TicketId,
                cancellationToken);

            if (model is null)
                return;

            model.Status = TicketStatus.Rejected;

            await _repository.UpdateAsync(model, cancellationToken);
        }
    }
}