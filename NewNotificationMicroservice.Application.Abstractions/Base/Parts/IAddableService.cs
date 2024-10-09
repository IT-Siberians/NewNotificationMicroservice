using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Services.Abstractions.Base.Parts
{
    public interface IAddableService<TCreatableModel, TKey>
        where TCreatableModel : class, ICreateModel
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Добавляет новую сущность в источник данных.
        /// </summary>
        /// <param name="entity">Сущность, используемая для создания новой записи.</param>
        /// <returns>Идентификатор новой сущности типа <typeparamref name="TKey"/>.</returns>
        Task<TKey?> AddAsync(TCreatableModel entity, CancellationToken cancellationToken);
    }
}
