using NewNotificationMicroservice.Domain.Entities.Base;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts
{
    /// <summary>
    /// Представляет абстракцию репозитория для методов получения сущности.
    /// </summary>
    /// <typeparam name="TEntity"> Тип Entity для репозитория. </typeparam>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IGetableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Получить сущность коллекцию сущностей.
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
        /// <returns> Коллекция сущностей. </returns>
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);

        /// <summary>
        /// Получить сущность.
        /// </summary>
        /// <param name="id"> Идентификатор сущности. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Cущность. </returns>
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    }
}
