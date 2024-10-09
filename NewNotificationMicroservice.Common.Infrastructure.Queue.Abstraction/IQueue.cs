using NewNotificationMicroservice.Domain.Entities;

namespace NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction
{
    public interface IQueue<T>
    {
        public T QueueName { get; }
        public MessageType Type { get; }
    }
}
