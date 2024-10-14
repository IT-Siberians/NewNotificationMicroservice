using NewNotificationMicroservice.Domain.Entities.Enums;

namespace NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction
{
    public interface IProducerService<TModelEvent>
    {
        void Send(TModelEvent message, Direction direction);
    }
}
