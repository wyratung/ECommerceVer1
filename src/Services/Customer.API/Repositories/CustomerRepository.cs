using AutoMapper;
using Common.Contracts.Interfaces;
using Common.Infas.Repositories;
using Common.Shared.DTOs.Customer;
using Customer.API.Entities;
using Customer.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Repositories
{
    public class CustomerRepository : RepositoryBaseAsync<CustomerEntity, int, CustomerContext>,
    ICustomerRepository
    {
        public CustomerRepository(CustomerContext context, IUnitOfWork<CustomerContext> unitOfWork)
            : base(context, unitOfWork)
        {
        }

        public async Task<CustomerEntity?> GetCustomerByUserNameAsync(string userName) => await FindByCondition(x => x.UserName.Equals(userName))
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<CustomerEntity>> GetCustomers() => await FindAll().ToListAsync();
    }
}
