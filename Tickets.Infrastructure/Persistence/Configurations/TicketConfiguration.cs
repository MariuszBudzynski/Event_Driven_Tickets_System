using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Tickets;

namespace Tickets.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Entity Framework Core configuration for the Ticket aggregate.
    /// 
    /// Defines how the domain model is mapped to the database schema.
    /// </summary>
    public sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever();

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(t => t.Status)
                .IsRequired();

            builder.Ignore(t => t.DomainEvents);
        }
    }
}
