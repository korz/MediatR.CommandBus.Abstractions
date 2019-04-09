namespace MediatR.CommandBus.Abstractions
{
    public interface IEventHandler<in TEvent> : IRequestHandler<TEvent> where TEvent : IEvent
    {
    }
}
