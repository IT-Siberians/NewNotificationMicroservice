using NewNotificationMicroservice.Domain.Entities.Base;
using NewNotificationMicroservice.Domain.Repositories.Abstractions.Base.Parts;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions.Base
{
    /// <summary>
    /// Абстракцию базового репозиторий позволяющего получать и добавлять сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepository<TEntity, TKey>
        : IGetableRepository<TEntity, TKey>,
        IAddableRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>;
}
