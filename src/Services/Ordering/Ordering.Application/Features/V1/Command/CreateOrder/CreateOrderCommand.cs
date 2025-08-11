using AutoMapper;
using Common.Shared.SeedWork;
using MediatR;
using Ordering.Application.Common.Mappings;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.V1.Command.CreateOrder
{
    public class CreateOrderCommand : CreateOrUpdateCommand, IRequest<ApiResult<long>>, IMapFrom<OrderEntity>
    {
        public string UserName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderCommand, OrderEntity>()
                .IgnoreAllNonExisting()
                .IgnoreNullProperties();
            profile.CreateMap<BasketCheckoutEvent, CreateOrderCommand>();
        }
    }
}
