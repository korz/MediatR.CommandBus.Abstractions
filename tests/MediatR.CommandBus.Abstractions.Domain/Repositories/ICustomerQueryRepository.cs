using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR.CommandBus.Abstractions.Contracts;

namespace MediatR.CommandBus.Abstractions.Domain.Repositories
{
    public interface ICustomerQueryRepository
    {
        IList<Customer> GetAll();
        Task<IList<Customer>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Customer GetById(int id);
        Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken));

        IList<Customer> GetByFirstName(string firstName);
        Task<IList<Customer>> GetByFirstNameAsync(string firstName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
