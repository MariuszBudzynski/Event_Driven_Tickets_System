using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Tickets;

namespace Tickets.Infrastructure
{
    /// <summary>
    /// Entity Framework Core database context for the Tickets system.
    /// 
    /// Acts as the Unit of Work boundary and manages persistence
    /// of all aggregates.
    /// </summary>
    public sealed class TicketsDbContext : DbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options) {}

        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(TicketsDbContext).Assembly);
        }
    }
}
