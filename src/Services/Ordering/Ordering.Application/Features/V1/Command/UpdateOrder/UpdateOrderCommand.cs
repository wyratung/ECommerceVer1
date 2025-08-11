using AutoMapper;
using Common.Shared.SeedWork;
using MediatR;
using Ordering.Application.Common.Mappings;
using Ordering.Application.Features.V1.Command.CreateOrder;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.V1.Command.UpdateOrder
{
    public class UpdateOrderCommand : CreateOrderCommand, IRequest<ApiResult<long>>, IMapFrom<OrderEntity>
    {
        public void SetId(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderCommand, OrderEntity>()
                .IgnoreAllNonExisting()
                .IgnoreNullProperties()
                // Do not allow change order status, only change status through consumer
                .ForMember(dest => dest.Status, opt => opt.Ignore());
        }
    }
}
