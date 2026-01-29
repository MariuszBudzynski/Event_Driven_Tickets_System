using Tickets.Application.Commands.CreateTicket;
using Tickets.Application.Tests.Fakes;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Tests
{
    public class CreateTicketCommandHandlerTests
    {
        [Fact]
        public async Task Commits_when_ticket_is_created()
        {
            //Arrange
            var ticketId = Guid.NewGuid();
            var title = "Test";
            var description = "Desc";
            var repository = new FakeTicketRepositoryForCreate();
            var unitOfWork = new FakeUnitOfWork();
            var handler = new CreateTicketCommandHandler(
            repository,
            unitOfWork);
            var command = new CreateTicketCommand(ticketId, title, description);

            //Act
            await handler.HandleAsync(command, CancellationToken.None);

            //Assert
            Assert.True(repository.AddCalled);
            Assert.True(unitOfWork.CommitCalled);
        }
    }
}