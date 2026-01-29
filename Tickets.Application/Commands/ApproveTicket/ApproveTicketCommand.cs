namespace Tickets.Application.Commands.ApproveTicket
{
    public sealed record ApproveTicketCommand(
        Guid TicketId
        );
}
