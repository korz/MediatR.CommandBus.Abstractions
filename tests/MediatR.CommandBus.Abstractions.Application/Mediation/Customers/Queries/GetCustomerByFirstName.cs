using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR.CommandBus.Abstractions.Contracts;
using MediatR.CommandBus.Abstractions.Domain.Repositories;
using MediatR.CommandBus.Abstractions.Shared;

namespace MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Queries
{
    public class GetCustomerByFirstName
    {
        public class Query : IQuery<IList<Customer>>
        {
            public string FirstName { get; set; }
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                this.RuleFor(x => x.FirstName)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("The FirstName cannot be blank or null.");
            }
        }

        public class Handler : IQueryHandler<Query, IList<Customer>>
        {
            private readonly ICustomerQueryRepository repository;
            private readonly Validator validator;

            public Handler(ICustomerQueryRepository repository)
            {
                this.repository = repository;
                this.validator = new Validator();
            }

            public async Task<IList<Customer>> Handle(Query query, CancellationToken cancellationToken = default(CancellationToken))
            {
                var validations = this.validator.Validate(query);

                if (!validations.IsValid)
                {
                    return await new List<Customer>().FromResult();
                }

                return await this.repository.GetByFirstNameAsync(query.FirstName, cancellationToken);
            }
        }
    }
}
