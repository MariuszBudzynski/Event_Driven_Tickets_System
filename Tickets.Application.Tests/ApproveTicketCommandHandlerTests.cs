using Tickets.Application.Commands.ApproveTicket;
using Tickets.Application.Exceptions;
using Tickets.Application.Tests.Fakes;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Tests
{
    public class ApproveTicketCommandHandlerTests
    {
        [Fact]
        public async Task Throws_when_ticket_does_not_exist()
        {
            //Arrange
            var commandId = Guid.NewGuid();
            var repository = new FakeTicketRepositoryForExistingTicket(null);
            var unitOfWork = new FakeUnitOfWork();
            var handler = new ApproveTicketCommandHandler(
            repository,
            unitOfWork);
            var command = new ApproveTicketCommand(commandId);

            //Act + Assert
            await Assert.ThrowsAsync<TicketNotFoundException>(
                () => handler.HandleAsync(command, CancellationToken.None)
                );
        }

        [Fact]
        public async Task Commits_when_ticket_is_approved()
        {
            //Arrange
            var ticketId = Guid.NewGuid();
            var commandId = Guid.NewGuid();
            var title = "Test";
            var description = "Desc";
            var ticket = new Ticket(ticketId, title, description);
            var repository = new FakeTicketRepositoryForExistingTicket(ticket);
            var unitOfWork = new FakeUnitOfWork();
            var handler = new ApproveTicketCommandHandler(
            repository,
            unitOfWork);
            var command = new ApproveTicketCommand(commandId);

            //Act
            ticket.Submit();
            await handler.HandleAsync(command, CancellationToken.None);

            //Assert
            Assert.True(unitOfWork.CommitCalled);
            Assert.True(repository.GetByIdCalled);
        }
    }
}
