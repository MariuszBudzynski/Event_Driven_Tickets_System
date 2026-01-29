namespace Tickets.Application.Exceptions
{
    /// <summary>
    /// Represents an application error that occurs
    /// when a ticket with the specified identifier
    /// cannot be found.
    /// </summary>
    public sealed class TicketNotFoundException : Exception
    {
        public Guid TicketId { get; }

        public TicketNotFoundException(Guid ticketId) : base($"Ticket with id '{ticketId}' was not found.")
        {
            TicketId = ticketId;
        }
    }
}
