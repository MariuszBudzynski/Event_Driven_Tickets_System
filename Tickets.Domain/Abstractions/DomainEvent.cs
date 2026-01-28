namespace Tickets.Domain.Abstractions
{
    /// <summary>
    /// Base class for all domain events.
    /// 
    /// A domain event represents something that has happened
    /// in the business domain and may be of interest to other
    /// parts of the system.
    /// </summary>
    public abstract class DomainEvent
    {
        public DateTime OccurredOn { get;} = DateTime.UtcNow;
    }
}
