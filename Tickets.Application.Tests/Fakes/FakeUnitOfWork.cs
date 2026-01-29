using Tickets.Application.Abstractions;

namespace Tickets.Application.Tests.Fakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public bool CommitCalled { get; private set; }
        public Task CommitAsync(CancellationToken cancellationToken)
        {
            CommitCalled = true;
            return Task.CompletedTask;
        }
    }
}
