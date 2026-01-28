using Tickets.Domain.Abstractions;

namespace Tickets.Domain.Events
{
    public sealed class TicketCreatedEvent : DomainEvent
    {
        public Guid TicketId { get;}

        public TicketCreatedEvent(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}