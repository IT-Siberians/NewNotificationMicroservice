using MassTransit;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Domain.Entities.Enums;
using Otus.QueueDto;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.MassTransit
{
    public class MTProducerService(IPublishEndpoint publishEndpoint) : IProducerService<MessageEvent>
    {
        public void Send(MessageEvent message, Direction direction)
        {
            publishEndpoint.Publish(message);
        }
    }
}
