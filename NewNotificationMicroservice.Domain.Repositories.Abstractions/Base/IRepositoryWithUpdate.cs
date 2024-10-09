using NewNotificationMicroservice.Domain.Entities.Base;
using NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions.Base
{
    /// <summary>
    /// Абстракцию базового репозиторий позволяющего получать, добавлять и обновлять сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepositoryWithUpdate<TEntity, TKey>
        : IRepository<TEntity, TKey>,
        IUpdatableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
}
