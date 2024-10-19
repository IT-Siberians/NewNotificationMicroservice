using Microsoft.EntityFrameworkCore;
using NewNotificationMicroservice.Infrastructure.EntityFramework;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Models;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.ValueObject;
using NewNotificationMicroservice.Infrastructure.Repositories.Implementations.Ef.Base;

namespace NewNotificationMicroservice.Infrastructure.Repositories.Implementations.Ef
{
    /// <summary>
    /// Репозиторий для работы с очередями шины
    /// </summary>
    /// <param name="context">Контекст базы данных</param>
    public class BusQueueRepository(ApplicationDbContext context) : GetableRepository<BusQueue, Guid>(context), IBusQueueRepository
    {
        /// <summary>
        /// Получение типа события по имени очереди 
        /// </summary>
        /// <param name="queueName">Тип события</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Очередь шины или null, если не найдена</returns>
        public async Task<BusQueue?> GetTypeByQueueNameAsync(QueueName queueName, CancellationToken cancellationToken = default)
        {
            return await context.BusQueues.AsNoTracking().FirstOrDefaultAsync(x => x.QueueName == queueName && !x.IsRemoved, cancellationToken);
        }

        /// <summary>
        /// Добавление новой очереди шины
        /// </summary>
        /// <param name="queue">Очередь шины для добавления</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор добавленной очереди шины</returns>
        public async Task<Guid> AddAsync(BusQueue queue, CancellationToken cancellationToken = default)
        {
            context.Entry(queue.Type).State = EntityState.Modified;
            context.Types.Attach(queue.Type);
            context.Users.Attach(queue.CreatedByUser);
            context.BusQueues.Add(queue);
            await context.SaveChangesAsync(cancellationToken);

            return queue.Id;
        }

        /// <summary>
        /// Обновление существующей очереди шины
        /// </summary>
        /// <param name="queue">Очередь шины для обновления</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>True, если обновление прошло успешно, иначе false</returns>
        public async Task<bool> UpdateAsync(BusQueue queue, CancellationToken cancellationToken = default)
        {
            context.Entry(queue).State = EntityState.Modified;
            context.Entry(queue.Type).State = EntityState.Modified;
            context.Types.Attach(queue.Type);
            context.Entry(queue.ModifiedByUser!).State = EntityState.Modified;
            context.Users.Attach(queue.ModifiedByUser!);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Удаление очереди шины
        /// </summary>
        /// <param name="queue">Очередь шины для удаления</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>True, если удаление прошло успешно, иначе false</returns>
        public async Task<bool> DeleteAsync(BusQueue queue, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(queue, cancellationToken);
        }
    }
}