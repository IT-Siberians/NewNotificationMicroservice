using NewNotificationMicroservice.Domain.Entities.Base;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts
{
    /// <summary>
    /// Представляет абстракцию репозитория для удаления сущностей.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий.</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности, обычно первичного ключа.</typeparam>
    public interface IDeletableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Была ли сущность удалена. </returns>
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
