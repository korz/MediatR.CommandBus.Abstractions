namespace MediatR.CommandBus.Abstractions
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
