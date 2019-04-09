using MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Commands;
using MediatR.CommandBus.Abstractions.Domain.Repositories;
using MediatR.CommandBus.Abstractions.Tests.Composition;
using NUnit.Framework;

namespace MediatR.CommandBus.Abstractions.Tests.Mediation.Customers.Commands
{
    public class SetCustomerInactiveTests
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

            Assert.IsNotNull(customer);
            Assert.AreEqual("Melissa", customer.FirstName);
            Assert.AreEqual("Labadie", customer.LastName);
            Assert.AreEqual(true, customer.IsActive);

            var command = new SetCustomerInactive.Command
            {
                Customer = customer
            };

            Mediator.Send(command).Wait();

            var modifiedCustomer = QueryRepository.GetById(1);

            Assert.IsNotNull(modifiedCustomer);
            Assert.AreEqual("Melissa", modifiedCustomer.FirstName);
            Assert.AreEqual("Labadie", modifiedCustomer.LastName);
            Assert.AreEqual(false, modifiedCustomer.IsActive);
        }

        [Test]
        public void Null_Customer()
        {
            var command = new SetCustomerInactive.Command
            {
                Customer = null
            };

            Mediator.Send(command).Wait();

            var modifiedCustomer = QueryRepository.GetById(1);

            Assert.IsNotNull(modifiedCustomer);
            Assert.AreEqual("Melissa", modifiedCustomer.FirstName);
            Assert.AreEqual("Labadie", modifiedCustomer.LastName);
            Assert.AreEqual(true, modifiedCustomer.IsActive);
        }
    }
}
