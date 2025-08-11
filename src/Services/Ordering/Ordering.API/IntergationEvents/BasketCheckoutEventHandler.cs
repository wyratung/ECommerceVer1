using AutoMapper;
using Common.EvenBus.IntergationEvents.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.V1.Command.CreateOrder;
using Serilog;
namespace Ordering.API.IntergationEvents
{
    public class BasketCheckoutEventHandler : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly Serilog.ILogger _logger;

        public BasketCheckoutEventHandler(IMediator mediator, IMapper mapper, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CreateOrderCommand>(context.Message);
            var result = await _mediator.Send(command);
            _logger.Information($"BasketCheckoutEvent consumed successfully." +
                $"Order is created with id: {result.Data}");
        }
    }
}
