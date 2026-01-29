namespace Tickets.Application.Abstractions
{
    /// <summary>
    /// Represents a unit of work that coordinates
    /// the persistence of changes and ensures
    /// transactional consistency.
    /// </summary>
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
