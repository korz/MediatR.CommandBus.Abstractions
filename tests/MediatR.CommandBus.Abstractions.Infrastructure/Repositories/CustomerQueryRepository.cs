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
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly IList<Customer> _customers;

        public CustomerQueryRepository()
        {
            this._customers = FakeData.GetCustomers().ToList();
        }

        public IList<Customer> GetAll()
        {
            return this._customers;
        }

        public async Task<IList<Customer>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._customers.FromResult();
        }

        public Customer GetById(int id)
        {
            return this._customers.SingleOrDefault(x => x.Id == id);
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._customers.SingleOrDefault(x => x.Id == id).FromResult();
        }

        public IList<Customer> GetByFirstName(string firstName)
        {
            return this._customers.Where(x => x.FirstName.Equals(firstName)).ToList();
        }

        public async Task<IList<Customer>> GetByFirstNameAsync(string firstName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._customers.Where(x => x.FirstName.Equals(firstName)).ToList().FromResult();
        }
    }
}
