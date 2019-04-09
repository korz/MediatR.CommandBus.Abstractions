namespace MediatR.CommandBus.Abstractions
{
    public abstract class QueryHandler<TQuery, TResult> : RequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
