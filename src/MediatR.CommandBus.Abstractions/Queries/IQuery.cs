namespace MediatR.CommandBus.Abstractions
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
