using NewNotificationMicroservice.Domain.Entities.Base;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts
{
    /// <summary>
    /// Представляет абстракцию репозитория для обновления сущностей.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий.</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности, обычно первичного ключа.</typeparam>
    public interface IUpdatableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Для сущности проставить состояние - что она изменена.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Была ли сущность обновлена. </returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
