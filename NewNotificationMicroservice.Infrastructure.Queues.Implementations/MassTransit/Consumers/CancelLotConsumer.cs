using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto.Lot;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Consumers
{
    public class CancelLotConsumer(ILogger<CancelLotConsumer> logger, IMediator mediator) : IConsumer<CancelLotEvent>
    {
        public async Task Consume(ConsumeContext<CancelLotEvent> context)
        {
            var result = await mediator.Send(new CancelLotCommand<CancelLotEvent>(context.Message));

            if (!result)
            {
                logger.LogWarning("Failed to send email, message will be redelivered.");
                await context.Redeliver(TimeSpan.FromSeconds(10));
            }
        }
    }
}
