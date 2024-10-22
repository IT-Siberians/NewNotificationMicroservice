using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto.User;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Consumers
{
    public class UpdateUserConsumer(ILogger<UpdateUserConsumer> logger, IMediator mediator) : IConsumer<UpdateUserEvent>
    {
        public async Task Consume(ConsumeContext<UpdateUserEvent> context)
        {
            var result = await mediator.Send(new UpdateUserCommand<UpdateUserEvent>(context.Message));

            if (!result)
            {
                logger.LogWarning("Failed to update user, message will be redelivered.");
                await context.Redeliver(TimeSpan.FromSeconds(10));
            }
        }
    }
}
