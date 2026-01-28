namespace Tickets.Domain.Tickets
{
    /// <summary>
    /// Represents the lifecycle states of a ticket.
    /// 
    /// The status defines which operations are allowed
    /// at any given point in time.
    /// </summary>
    public enum TicketStatus
    {
        Draft = 0,
        Submitted = 1,
        Approved = 2,
        Rejected =3
    }
}