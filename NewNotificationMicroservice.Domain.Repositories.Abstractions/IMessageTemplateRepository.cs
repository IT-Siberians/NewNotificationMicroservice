using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Domain.Repositories.Abstractions.Base;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для управления объектами типа <see cref="MessageTemplate"/>.
    /// </summary>
    public interface IMessageTemplateRepository : IRepositoryWithUpdateAndDelete<MessageTemplate, Guid>
    {
        /// <summary>
        /// Возвращает коллекцию шаблонов сообщений, соответствующих указанному типу.
        /// </summary>
        /// <param name="id">Идентификатор типа</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns>Коллекция шаблонов сообщений</returns>
        Task<IEnumerable<MessageTemplate>> GetByTypeIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает шаблон сообщения, соответствующий указанной очереди и языку.
        /// </summary>
        /// <param name="id">Идентификатор очереди</param>
        /// <param name="language">Язык шаблона сообщения</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns>Шаблон сообщения или null, если не найден</returns>
        Task<MessageTemplate?> GetByQueueAndLanguageAsync(Guid id, Language language, CancellationToken cancellationToken);
    }
}
