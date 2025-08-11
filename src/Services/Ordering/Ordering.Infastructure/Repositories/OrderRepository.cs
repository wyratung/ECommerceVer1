using Common.Infas.Repositories;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Repositories
{
    public class OrderRepository : RepositoryBaseAsync<OrderEntity, long, OrderContext>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext, IUnitOfWork<OrderContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public async Task<IEnumerable<OrderEntity>> GetOrdersByUserName(string userName)
        {
            var result = await FindByCondition(o => o.UserName.Equals(userName)).ToListAsync();
            return result;
        }
    }
}
