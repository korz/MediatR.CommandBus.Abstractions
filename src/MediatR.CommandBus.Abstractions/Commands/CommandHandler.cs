namespace MediatR.CommandBus.Abstractions
{
    public abstract class CommandHandler<TCommand> : RequestHandler<TCommand> where TCommand : ICommand
    {
    }
}
