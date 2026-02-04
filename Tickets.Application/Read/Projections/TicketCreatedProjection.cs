using Tickets.Application.Abstractions;
using Tickets.Application.Read.Models;
using Tickets.Domain.Events;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Read.Projections
{
    /// <summary>
    /// Projects ticket creation events into read models.
    /// </summary>
    public sealed class TicketCreatedProjection
    {
        private readonly ITicketReadRepository _repository;

        public TicketCreatedProjection(ITicketReadRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(
        TicketCreatedEvent domainEvent,
        CancellationToken cancellationToken)
        {
            var model = new TicketReadModel
            {
                Id = domainEvent.TicketId,
                Title = domainEvent.Title,
                Status = TicketStatus.Draft,
                CreatedAt = domainEvent.OccurredOn
            };

            await _repository.AddAsync(model, cancellationToken);
        }
    }
}
