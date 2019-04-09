namespace MediatR.CommandBus.Abstractions
{
    public abstract class EventHandler<TEvent, TResult> : RequestHandler<TEvent, TResult> where TEvent : IEvent<TResult>
    {
    }
}
