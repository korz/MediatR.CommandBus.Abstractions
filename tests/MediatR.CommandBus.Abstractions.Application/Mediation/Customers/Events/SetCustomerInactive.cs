using FluentValidation;
using MediatR.CommandBus.Abstractions.Contracts;
using MediatR.CommandBus.Abstractions.Shared;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Events
{
    public static class CustomerWasUpdated
    {
        public class Event : IEvent
        {
            public Customer Customer { get; set; }
        }

        public class Validator : AbstractValidator<Event>
        {
            public Validator()
            {
                this.RuleFor(x => x.Customer)
                    .NotNull()
                    .WithMessage("Customer cannot be null.");
            }
        }

        public class Handler : IEventHandler<Event>
        {
            private readonly Validator validator;

            public Handler()
            {
                this.validator = new Validator();
            }

            public async Task<Unit> Handle(Event occurrence, CancellationToken cancellationToken)
            {
                var validations = this.validator.Validate(occurrence);

                if (!validations.IsValid)
                {
                    return await new Unit().FromResult();
                }

                Log.Logger.Information("Customer {FirstName} {LastName} was updated.", occurrence.Customer.FirstName, occurrence.Customer.LastName);

                return await new Unit().FromResult();
            }
        }
    }
}
