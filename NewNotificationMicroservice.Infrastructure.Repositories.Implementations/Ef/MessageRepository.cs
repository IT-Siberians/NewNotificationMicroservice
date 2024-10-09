using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.Repositories.Abstractions;
using NewNotificationMicroservice.Infrastructure.EntityFramework;
using NewNotificationMicroservice.Infrastructure.Repositories.Implementations.Ef.Base;

namespace NewNotificationMicroservice.Infrastructure.Repositories.Implementations.Ef
{
    /// <summary>
    /// Репозиторий для работы с сообщениями в базе данных.
    /// Реализует интерфейс <see cref="IMessageRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных для работы с сообщениями.</param>
    public class MessageRepository(ApplicationDbContext context) : GetableRepository<Message, Guid>(context), IMessageRepository
    {
        /// <summary>
        /// Добавляет новое сообщение в базу данных.
        /// </summary>
        /// <param name="message">Сущность сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного сообщения.</returns>
        public async Task<Guid> AddAsync(Message message, CancellationToken cancellationToken = default)
        {
            context.Types.Attach(message.Type);
            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();

            return message.Id;
        }
    }
}