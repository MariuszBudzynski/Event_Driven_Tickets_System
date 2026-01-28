using Tickets.Domain.Abstractions;

namespace Tickets.Domain.Events
{
    /// <summary>
    /// Domain event raised when a ticket is successfully submitted.
    /// 
    /// This event represents a completed business action and
    /// should not contain any behavior.
    /// </summary>
    public sealed class TicketApprovedEvent : DomainEvent
    {
        public Guid TicketId { get; }

        public TicketApprovedEvent(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}
