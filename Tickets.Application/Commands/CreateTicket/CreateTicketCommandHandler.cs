using Tickets.Application.Abstractions;
using Tickets.Domain.Tickets;

namespace Tickets.Application.Commands.CreateTicket
{
    /// <summary>
    /// Handles the creation of a new ticket.
    /// 
    /// This handler coordinates the domain logic and
    /// persists the newly created aggregate.
    /// </summary>
    public sealed class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand>
    {
        private readonly ITicketRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(
            ITicketRepository repository,
            IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
        CreateTicketCommand command,
        CancellationToken cancellationToken)
        {
            var ticket = new Ticket(
                command.TicketId,
                command.Title,
                command.Description
                );

            await _repository.AddAsync(ticket, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
