using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto.Lot;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Consumers
{
    public class WonLotConsumer(ILogger<WonLotConsumer> logger, IMediator mediator) : IConsumer<WonLotEvent>
    {
        public async Task Consume(ConsumeContext<WonLotEvent> context)
        {
            var result = await mediator.Send(new WonLotCommand<WonLotEvent>(context.Message));

            if (!result)
            {
                logger.LogWarning("Failed to send email, message will be redelivered.");
                await context.Redeliver(TimeSpan.FromSeconds(10));
            }
        }
    }
}
