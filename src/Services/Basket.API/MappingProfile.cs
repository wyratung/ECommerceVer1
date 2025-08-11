using AutoMapper;
using Basket.API.Models;
using Common.EvenBus.IntergationEvents.Events;

namespace Basket.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>();
        }
    }
}
