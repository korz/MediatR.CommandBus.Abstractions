using System.Threading;
using System.Threading.Tasks;
using MediatR.CommandBus.Abstractions.Contracts;

namespace MediatR.CommandBus.Abstractions.Domain.Repositories
{
    public interface ICustomerCommandRepository
    {
        void Create(Customer customer);
        Task CreateAsync(Customer customer, CancellationToken cancellationToken = default(CancellationToken));

        void Update(int id, Customer customer);
        Task UpdateAsync(int id, Customer customer, CancellationToken cancellationToken = default(CancellationToken));

        void Delete(int id);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
