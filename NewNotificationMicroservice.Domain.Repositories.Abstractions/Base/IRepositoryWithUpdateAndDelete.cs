using NewNotificationMicroservice.Domain.Entities.Base;
using NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions.Base
{
    /// <summary>
    /// Абстракцию базового репозиторий позволяющего получать, добавлять, обновлять и удалять сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepositoryWithUpdateAndDelete<TEntity, TKey>
        : IRepositoryWithUpdate<TEntity, TKey>,
        IDeletableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
}
