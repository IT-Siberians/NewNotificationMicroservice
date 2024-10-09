using NewNotificationMicroservice.Domain.Entities.Base;
using NewNotificationMicroservice.Domain.Repositories.Abstractions.Base;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Models;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.ValueObject;

namespace NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction
{
    /// <summary>
    /// Интерфейс репозитория для работы с очередями шины
    /// </summary>
    public interface IBusQueueRepository: IRepositoryWithUpdateAndDelete<BusQueue, Guid>
    {
        /// <summary>
        /// Получение типа события по имени очереди 
        /// </summary>
        /// <param name="queueName">Тип события</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Очередь шины или null, если не найдена</returns>
        Task<BusQueue?> GetTypeByQueueNameAsync(QueueName queueName, CancellationToken cancellationToken);
    }
}