using NewNotificationMicroservice.Domain.Entities.Enums;

namespace NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction
{
    public interface IProducerService
    {
        void SendMessage(SendMessage message, Direction direction);
    }
}
