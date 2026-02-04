using Tickets.Domain.Tickets;

namespace Tickets.Application.Read.Models
{
    public sealed class TicketReadModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}