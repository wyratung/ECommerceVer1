using Common.Shared.SeedWork;
using MediatR;
using Ordering.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.V1.Queries
{
    public class GetOrdersQuery : IRequest<ApiResult<List<OrderDto>>>
    {
        public string UserName { get; init; }
        public GetOrdersQuery(string userName)
        {
            ArgumentNullException.ThrowIfNull(nameof(userName));
            UserName = userName;
        }
    }
}
