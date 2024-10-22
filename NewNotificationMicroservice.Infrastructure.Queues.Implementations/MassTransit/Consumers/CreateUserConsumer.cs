using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto.User;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit.Consumers
{
    public class CreateUserConsumer(ILogger<CreateUserConsumer> logger, IMediator mediator) : IConsumer<CreateUserEvent>
    {
        public async Task Consume(ConsumeContext<CreateUserEvent> context)
        {
            var result = await mediator.Send(new CreateUserCommand<CreateUserEvent>(context.Message));

            if (!result)
            {
                logger.LogWarning("Failed to create user, message will be redelivered.");
                await context.Redeliver(TimeSpan.FromSeconds(10));
            }
        }
    }
}
