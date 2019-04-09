using MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Queries;
using MediatR.CommandBus.Abstractions.Tests.Composition;
using NUnit.Framework;

namespace MediatR.CommandBus.Abstractions.Tests.Mediation.Customers.Queries
{
    public class GetCustomerByFirstNameTests
    {
        private IMediator Mediator;

        [SetUp]
        public void Setup()
        {
            Mediator = CompositionRoot.Get<IMediator>();
        }

        [Test]
        public void Valid_FirstName()
        {
            var query = new GetCustomerByFirstName.Query
            {
                FirstName = "Melissa"
            };

            var customers = Mediator.Send(query).GetAwaiter().GetResult();

            Assert.IsNotNull(customers);
            Assert.AreEqual(1, customers.Count);
            Assert.AreEqual("Melissa", customers[0].FirstName);
            Assert.AreEqual("Labadie", customers[0].LastName);
        }

        [Test]
        public void Null_FirstName()
        {
            var query = new GetCustomerByFirstName.Query
            {
                FirstName = null
            };

            var customers = Mediator.Send(query).GetAwaiter().GetResult();

            Assert.IsNotNull(customers);
            Assert.AreEqual(0, customers.Count);
        }

        [Test]
        public void Empty_FirstName()
        {
            var query = new GetCustomerByFirstName.Query
            {
                FirstName = ""
            };

            var customers = Mediator.Send(query).GetAwaiter().GetResult();

            Assert.IsNotNull(customers);
            Assert.AreEqual(0, customers.Count);
        }
    }
}
