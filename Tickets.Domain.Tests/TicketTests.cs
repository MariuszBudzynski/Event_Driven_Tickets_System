using Tickets.Domain.Events;
using Tickets.Domain.Tickets;

namespace Tickets.Domain.Tests
{
    public class TicketTests
    {

        [Fact]
        public void Creating_ticket_with_empty_title_throws_exception()
        {
            // Arrange
            var title = string.Empty;
            var description = "Desc";

            // Act
            var action = () => new Ticket(title, description);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(action);
            Assert.Equal("Ticket title cannot be empty", ex.Message);
        }

        [Fact]
        public void Ticket_is_created_correctly()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var ticket = new Ticket(title, description);

            // Act & Assert
            Assert.Equal(title, ticket.Title);
            Assert.Equal(description, ticket.Description);
            Assert.Equal(TicketStatus.Draft, ticket.Status);
            Assert.Single(ticket.DomainEvents);
        }

        [Fact]
        public void Ticket_is_submitted_correctly()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var ticket = new Ticket(title, description);

            // Act
            ticket.Submit();

            // Assert
            Assert.Equal(TicketStatus.Submitted, ticket.Status);
            Assert.Contains(ticket.DomainEvents,e => e is TicketSubmittedEvent);
        }

        [Fact]
        public void Submitting_ticket_with_status_not_draft_throws_exception()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var exception = "Only draft tickets can be submitted";
            var ticket = new Ticket(title, description);
            ticket.Status = TicketStatus.Submitted;

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => ticket.Submit());

            // Assert
            Assert.NotNull(ex);
            Assert.Equal(exception, ex.Message);
        }

        [Fact]
        public void Ticket_is_approved_correctly()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var ticket = new Ticket(title, description);
            ticket.Status = TicketStatus.Submitted;

            // Act
            ticket.Approve();

            // Assert
            Assert.Equal(TicketStatus.Approved, ticket.Status);
            Assert.Contains(ticket.DomainEvents, e => e is TicketApprovedEvent);
        }

        [Fact]
        public void Approving_ticket_with_status_not_submitted_throws_exception()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var exception = "Only submitted tickets can be approved";
            var ticket = new Ticket(title, description);
            ticket.Status = TicketStatus.Draft;

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => ticket.Approve());

            // Assert
            Assert.NotNull(ex);
            Assert.Equal(exception, ex.Message);
        }

        [Fact]
        public void Ticket_is_rejected_correctly()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var reason = "Test reason";
            var ticket = new Ticket(title, description);
            ticket.Status = TicketStatus.Submitted;

            // Act
            ticket.Reject(reason);

            // Assert
            Assert.Equal(TicketStatus.Rejected, ticket.Status);
            Assert.Contains(ticket.DomainEvents, e => e is TicketRejectedEvent);
        }

        [Fact]
        public void Rejecting_ticket_with_status_not_submitted_throws_exception()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var reason = "Test reason";
            var exception = "Only submitted tickets can be rejected";
            var ticket = new Ticket(title, description);
            ticket.Status = TicketStatus.Draft;

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => ticket.Reject(reason));

            // Assert
            Assert.NotNull(ex);
            Assert.Equal(exception, ex.Message);
        }

        [Fact]
        public void Rejecting_ticket_with_no_reason_throws_exception()
        {
            // Arrange
            var title = "Test";
            var description = "Desc";
            var reason = string.Empty;
            var exception = "Rejection reason is required";
            var ticket = new Ticket(title, description);
            ticket.Status = TicketStatus.Submitted;

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => ticket.Reject(reason));

            // Assert
            Assert.NotNull(ex);
            Assert.Equal(exception, ex.Message);
        }
    }
}