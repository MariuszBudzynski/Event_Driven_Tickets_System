using Tickets.Domain.Abstractions;

namespace Tickets.Domain.Events
{
    /// <summary>
    /// Domain event raised when a ticket is successfully submitted.
    /// 
    /// This event represents a completed business action and
    /// should not contain any behavior.
    /// </summary>
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
