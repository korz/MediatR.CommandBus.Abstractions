using MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Commands;
using MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Events;
using MediatR.CommandBus.Abstractions.Domain.Repositories;
using MediatR.CommandBus.Abstractions.Tests.Composition;
using NUnit.Framework;

namespace MediatR.CommandBus.Abstractions.Tests.Mediation.Customers.Events
{
    public class CustomerWasUpdatedTests
    {
        private ICustomerQueryRepository QueryRepository;
        private IMediator Mediator;

        [SetUp]
        public void Setup()
        {
            QueryRepository = CompositionRoot.Get<ICustomerQueryRepository>();
            Mediator = CompositionRoot.Get<IMediator>();
        }

        [Test]
        public void Valid_Customer()
        {
            var customer = QueryRepository.GetById(1);

            var command = new SetCustomerInactive.Command { Customer = customer };
            Mediator.Send(command).Wait();

            var @event = new CustomerWasUpdated.Event { Customer = customer };
            Mediator.Send(@event).Wait();
        }

        [Test]
        public void Null_Customer()
        {
            var @event = new CustomerWasUpdated.Event { Customer = null };
            Mediator.Send(@event).Wait();
        }
    }
}
