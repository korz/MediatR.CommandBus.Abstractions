using MediatR.CommandBus.Abstractions.Contracts;
using MediatR.CommandBus.Abstractions.Infrastructure.Helpers;
using MediatR.CommandBus.Abstractions.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR.CommandBus.Abstractions.Domain.Repositories;

namespace MediatR.CommandBus.Console.Repositories
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly IList<Customer> _customers;

        public CustomerCommandRepository()
        {
            this._customers = FakeData.GetCustomers().ToList();
        }

        public void Create(Customer customer)
        {
            this._customers.Add(customer);
        }

        public async Task CreateAsync(Customer customer, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Extensions.RunTask(() => this._customers.Add(customer), cancellationToken);
        }

        public void Update(int id, Customer customer)
        {
            var retrievedCustomer = this._customers.SingleOrDefault(x => x.Id == id);

            if (retrievedCustomer == null)
            {
                this.Create(customer);

                return;
            }

            retrievedCustomer.FirstName = customer.FirstName;
            retrievedCustomer.LastName = customer.LastName;
            retrievedCustomer.IsActive = customer.IsActive;
            retrievedCustomer.FirstName = customer.FirstName;
        }

        public async Task UpdateAsync(int id, Customer customer, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Extensions.RunTask(() => this.Update(id, customer), cancellationToken);
        }

        public void Delete(int id)
        {
            var retrievedCustomer = this._customers.SingleOrDefault(x => x.Id == id);

            this._customers.Remove(retrievedCustomer);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Extensions.RunTask(() => this.Delete(id), cancellationToken);
        }
    }
}
