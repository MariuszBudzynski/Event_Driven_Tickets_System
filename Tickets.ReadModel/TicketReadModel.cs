using Tickets.Domain.Tickets;

namespace Tickets.ReadModel
{
    /// <summary>
    /// Read-only projection of a ticket used for queries.
    /// 
    /// This model is optimized for read operations and
    /// does not contain any business logic.
    /// </summary>
    public sealed class TicketReadModel
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = default!;
        public TicketStatus Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? ApprovedAt { get; init; }
        public string? RejectionReason { get; init; }
    }
}