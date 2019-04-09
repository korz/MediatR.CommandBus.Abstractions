using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR.CommandBus.Abstractions.Contracts;
using MediatR.CommandBus.Abstractions.Domain.Repositories;
using MediatR.CommandBus.Abstractions.Shared;

namespace MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Queries
{
    public class GetCustomerById
    {
        public class Query : IQuery<Customer>
        {
            public int Id { get; set; }
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                this.RuleFor(x => x.Id)
                    .GreaterThan(0)
                    .WithMessage("Id must be a valid integer.");
            }
        }

        public class Handler : IQueryHandler<Query, Customer>
        {
            private readonly ICustomerQueryRepository repository;
            private readonly Validator validator;

            public Handler(ICustomerQueryRepository repository)
            {
                this.repository = repository;
                this.validator = new Validator();
            }

            public async Task<Customer> Handle(Query query, CancellationToken cancellationToken = default(CancellationToken))
            {
                var validations = this.validator.Validate(query);

                if (!validations.IsValid)
                {
                    return await ((Customer)null).FromResult();
                }

                return await this.repository.GetByIdAsync(query.Id, cancellationToken);
            }
        }
    }
}
