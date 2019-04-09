namespace MediatR.CommandBus.Abstractions
{
    public abstract class EventHandler<TEvent> : RequestHandler<TEvent> where TEvent : IEvent
    {
    }
}
