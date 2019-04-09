namespace MediatR.CommandBus.Abstractions
{
    public abstract class AsyncCommandHandler<TCommand> : AsyncRequestHandler<TCommand> where TCommand : ICommand
    {
    }
}
