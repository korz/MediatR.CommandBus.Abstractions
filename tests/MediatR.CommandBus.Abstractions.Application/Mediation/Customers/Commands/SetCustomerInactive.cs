using FluentValidation;
using MediatR.CommandBus.Abstractions.Contracts;
using MediatR.CommandBus.Abstractions.Domain.Repositories;
using MediatR.CommandBus.Abstractions.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Commands
{
    public static class SetCustomerInactive
    {
        public class Command : ICommand
        {
            public Customer Customer { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                this.RuleFor(x => x.Customer)
                    .NotNull()
                    .WithMessage("Customer cannot be null.");
            }
        }

        public class Handler : ICommandHandler<Command>
        {
            private readonly ICustomerCommandRepository repository;
            private readonly Validator validator;

            public Handler(ICustomerCommandRepository repository)
            {
                this.repository = repository;
                this.validator = new Validator();
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var validations = this.validator.Validate(command);

                if (!validations.IsValid)
                {
                    return await new Unit().FromResult();
                }

                command.Customer.IsActive = false;

                await this.repository.UpdateAsync(command.Customer.Id, command.Customer, cancellationToken);

                return await new Unit().FromResult();
            }
        }
    }
}
