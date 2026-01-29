using Tickets.Application.Abstractions;
using Tickets.Application.Exceptions;

namespace Tickets.Application.Commands.SubmitTicket
{
    /// <summary>
    /// Handles the submission of an existing ticket.
    /// 
    /// This handler loads the ticket aggregate,
    /// executes the domain operation and persists the result.
    /// </summary>
    public sealed class SubmitTicketCommandHandler : ICommandHandler<SubmitTicketCommand>
    {
        private readonly ITicketRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SubmitTicketCommandHandler(
            ITicketRepository repository,
            IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
        SubmitTicketCommand command,
        CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(
                command.TicketId,
                cancellationToken);

            if (ticket is null)
                throw new TicketNotFoundException(command.TicketId);

            ticket.Submit();

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
