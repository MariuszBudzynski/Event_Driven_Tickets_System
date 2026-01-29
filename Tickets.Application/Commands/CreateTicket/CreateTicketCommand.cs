namespace Tickets.Application.Commands.CreateTicket
{

    /// <summary>
    /// Represents a request to create a new ticket.
    /// 
    /// This command captures the intent to create a ticket
    /// but does not contain any business logic.
    /// </summary>
    public sealed record CreateTicketCommand(
        Guid TicketId,
        string Title,
        string Description
        );
}
