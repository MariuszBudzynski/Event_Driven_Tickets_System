using Tickets.Application.Abstractions;
using Tickets.Application.Commands.SubmitTicket;
using Tickets.Application.Exceptions;

namespace Tickets.Application.Commands.ApproveTicket
{
    /// <summary>
    /// Handles the approval of an existing ticket.
    /// 
    /// This handler is responsible for retrieving the ticket aggregate
    /// and invoking the domain operation that performs the approval.
    /// Persistence is handled externally via Unit of Work.
    /// </summary>
    public sealed class ApproveTicketCommandHandler : ICommandHandler<ApproveTicketCommand>
    {
        private readonly ITicketRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ApproveTicketCommandHandler(
            ITicketRepository repository,
            IUnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(
       ApproveTicketCommand command,
       CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(
                command.TicketId,
                cancellationToken);

            if (ticket is null)
                throw new TicketNotFoundException(command.TicketId);

            ticket.Approve();

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}