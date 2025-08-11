using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.V1.Command.DeleteOrder
{
    public interface IDeleteOrderCommandHandler
    {
        Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken);
    }
}
