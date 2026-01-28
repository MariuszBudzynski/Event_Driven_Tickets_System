using Tickets.Domain.Abstractions;

namespace Tickets.Domain.Events
{
    public sealed class TicketApprovedEvent : DomainEvent
    {
        public Guid TicketId { get; }

        public TicketApprovedEvent(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}
