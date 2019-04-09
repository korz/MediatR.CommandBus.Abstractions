namespace MediatR.CommandBus.Abstractions
{
    public abstract class AsyncEventHandler<TEvent> : AsyncRequestHandler<TEvent> where TEvent : IEvent
    {
    }
}
