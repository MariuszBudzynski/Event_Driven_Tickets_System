using Tickets.Domain.Abstractions;
using Tickets.Domain.Events;

namespace Tickets.Domain.Tickets
{
    /// <summary>
    /// Represents a support ticket aggregate root.
    /// 
    /// The Ticket is responsible for enforcing all business rules related
    /// to ticket lifecycle and state transitions.
    /// 
    /// All modifications to the ticket must go through this class.
    /// </summary>
    /// 
    public class Ticket : Entity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }

        private Ticket() { }

        public Ticket(Guid ticketId, string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new InvalidOperationException("Ticket title cannot be empty");

            Id = ticketId;
            Title = title;
            Description = description;
            Status = TicketStatus.Draft;
            AddDomainEvent(new TicketCreatedEvent(Id));

        }

        public void Submit()
        {
            if (Status != TicketStatus.Draft)
                throw new InvalidOperationException("Only draft tickets can be submitted");

            Status = TicketStatus.Submitted;
            AddDomainEvent(new TicketSubmittedEvent(Id));
        }

        public void Approve()
        {
            if (Status != TicketStatus.Submitted)
                throw new InvalidOperationException("Only submitted tickets can be approved");

            Status = TicketStatus.Approved;
            AddDomainEvent(new TicketApprovedEvent(Id));
        }

        public void Reject(string reason)
        {
            if (Status != TicketStatus.Submitted)
                throw new InvalidOperationException("Only submitted tickets can be rejected");

            if (string.IsNullOrWhiteSpace(reason))
                throw new InvalidOperationException("Rejection reason is required");

            Status = TicketStatus.Rejected;
            AddDomainEvent(new TicketRejectedEvent(Id, reason));
        }
    }
}
