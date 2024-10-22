using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto.Lot;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Consumers
{
    public class BidPerLotConsumer(ILogger<BidPerLotConsumer> logger, IMediator mediator) : IConsumer<BidPerLotEvent>
    {
        public async Task Consume(ConsumeContext<BidPerLotEvent> context)
        {
            var result = await mediator.Send(new BidPerLotCommand<BidPerLotEvent>(context.Message));

            if (!result)
            {
                logger.LogWarning("Failed to send email, message will be redelivered.");
                await context.Redeliver(TimeSpan.FromSeconds(10));
            }
        }
    }
}
