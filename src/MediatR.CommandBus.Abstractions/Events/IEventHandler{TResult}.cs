namespace MediatR.CommandBus.Abstractions
{
    public interface IEventHandler<in TEvent, TResult> : IRequestHandler<TEvent, TResult> where TEvent : IEvent<TResult>
    {
    }
}
