namespace MediatR.CommandBus.Abstractions
{
    public interface IEvent<out TResult> : IRequest<TResult>
    {
    }
}
