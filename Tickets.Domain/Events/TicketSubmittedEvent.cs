using Tickets.Domain.Abstractions;

namespace Tickets.Domain.Events
{
    public sealed  class TicketSubmittedEvent : DomainEvent
    {
        public Guid TicketId { get; }
        public TicketSubmittedEvent(Guid ticketId)
        {
            TicketId = ticketId;
        }
    }
}