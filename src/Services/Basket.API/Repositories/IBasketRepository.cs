using Basket.API.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<Cart?> GetBasketByUserName(string userName);
        Task<Cart> CreateOrUpdate(Cart cart, DistributedCacheEntryOptions? option = default);
        Task<bool> DeleteBasketFromUserName(string userName);
    }
}
