using Tickets.Domain.Abstractions;

namespace Tickets.Domain.Events
{
    public class TicketRejectedEvent : DomainEvent
    {
        public Guid TicketId { get; }
        public string Reason { get; }

        public TicketRejectedEvent(Guid ticketId, string reason)
        {
            TicketId = ticketId;
            Reason = reason;
        }
    }
}
