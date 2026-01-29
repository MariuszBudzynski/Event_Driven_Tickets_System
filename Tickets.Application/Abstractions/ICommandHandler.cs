namespace Tickets.Application.Abstractions
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command, CancellationToken cancellationToken);
    }
}