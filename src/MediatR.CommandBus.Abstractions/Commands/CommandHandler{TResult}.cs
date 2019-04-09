namespace MediatR.CommandBus.Abstractions
{
    public abstract class CommandHandler<TCommand, TResult> : RequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
    }
}
