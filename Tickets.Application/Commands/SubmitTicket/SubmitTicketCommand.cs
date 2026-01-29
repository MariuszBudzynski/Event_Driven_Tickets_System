namespace Tickets.Application.Commands.SubmitTicket
{

    /// <summary>
    /// Represents a request to submit an existing ticket.
    /// 
    /// This command expresses the intent to move a ticket
    /// from Draft to Submitted state.
    /// </summary>
    public sealed record SubmitTicketCommand(
        Guid TicketId
        );
}