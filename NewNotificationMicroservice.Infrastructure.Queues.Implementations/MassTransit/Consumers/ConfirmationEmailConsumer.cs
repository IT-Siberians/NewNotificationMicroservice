using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto.Notification;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Consumers
{
    public class ConfirmationEmailConsumer(ILogger<ConfirmationEmailConsumer> logger, IMediator mediator) : IConsumer<ConfirmationEmailEvent>
    {
        public async Task Consume(ConsumeContext<ConfirmationEmailEvent> context)
        {
            var result = await mediator.Send(new ConfirmationEmailCommand<ConfirmationEmailEvent>(context.Message));

            if (!result)
            {
                logger.LogWarning("Failed to send email, message will be redelivered.");
                await context.Redeliver(TimeSpan.FromSeconds(10));
            }
        }
    }
}
