using NewNotificationMicroservice.Domain.Entities.Base;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts
{
    /// <summary>
    /// Представляет абстракцию репозитория добавления сущностей.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий.</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности, обычно первичного ключа.</typeparam>
    public interface IAddableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Добавленная сущность. </returns>
        Task<TKey> AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
