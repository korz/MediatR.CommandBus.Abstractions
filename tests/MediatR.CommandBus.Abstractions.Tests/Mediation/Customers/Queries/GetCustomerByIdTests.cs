using MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Queries;
using MediatR.CommandBus.Abstractions.Tests.Composition;
using NUnit.Framework;

namespace MediatR.CommandBus.Abstractions.Tests.Mediation.Customers.Queries
{
    public class GetCustomerByIdTests
    {
        private IMediator Mediator;

        [SetUp]
        public void Setup()
        {
            Mediator = CompositionRoot.Get<IMediator>();
        }

        [Test]
        public void Valid_Id()
        {
            var query = new GetCustomerById.Query
            {
                Id = 1
            };

            var customer = Mediator.Send(query).GetAwaiter().GetResult();

            Assert.IsNotNull(customer);
            Assert.AreEqual("Melissa", customer.FirstName);
            Assert.AreEqual("Labadie", customer.LastName);
        }

        [Test]
        public void Negative_Id()
        {
            var query = new GetCustomerById.Query
            {
                Id = -3
            };

            var customer = Mediator.Send(query).GetAwaiter().GetResult();

            Assert.IsNull(customer);
        }
    }
}
