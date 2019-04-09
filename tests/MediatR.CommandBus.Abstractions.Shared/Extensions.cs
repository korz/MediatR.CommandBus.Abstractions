using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.CommandBus.Abstractions.Shared
{
    public static class Extensions
    {
        public static Task<TResult> FromResult<TResult>(this TResult result, bool continueOnCapturedContext = false)
        {
            if (continueOnCapturedContext)
            {
                var task = new Task<TResult>(() => result);
                task.ConfigureAwait(false);

                task.Start();
                return task;
            }
            else
            {
                return Task.FromResult(result);
            }
        }

        public static Task RunTask(this Action action, CancellationToken cancellationToken = default(CancellationToken), bool continueOnCapturedContext = false)
        {
            if (continueOnCapturedContext)
            {
                var task = new Task(action, cancellationToken);
                task.ConfigureAwait(false);

                task.Start();
                return task;
            }
            else
            {
                return Task.Run(action, cancellationToken);
            }
        }
    }
}
