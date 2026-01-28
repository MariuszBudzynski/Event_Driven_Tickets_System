using Tickets.Domain.Abstractions;

namespace Tickets.Domain.Events
{
    /// <summary>
    /// Domain event raised when a ticket is successfully submitted.
    /// 
    /// This event represents a completed business action and
    /// should not contain any behavior.
    /// </summary>
    public sealed  class TicketSubmittedEvent : DomainEvent
    {
        public Guid TicketId { get; }
        public TicketSubmittedEvent(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}