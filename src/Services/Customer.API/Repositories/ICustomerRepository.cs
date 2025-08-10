using Common.Contracts.Interfaces;
using Common.Shared.DTOs.Customer;
using Customer.API.Entities;
using Customer.API.Persistence;

namespace Customer.API.Repositories
{
    public interface ICustomerRepository : IRepositoryBaseAsync<CustomerEntity, int, CustomerContext>
    {
        Task<CustomerEntity?> GetCustomerByUserNameAsync(string userName);
        Task<IEnumerable<CustomerEntity>> GetCustomers();
    }
}
