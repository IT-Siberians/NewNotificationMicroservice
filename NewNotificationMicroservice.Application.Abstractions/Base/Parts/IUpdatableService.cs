using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Services.Abstractions.Base.Parts
{
    public interface IUpdatableService<TUpdatableModel, TKey>
        where TUpdatableModel : class, IBaseModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Изменение сущности
        /// </summary>
        /// <param name="entity">Модель для изменения</param>
        /// <returns>Булевое значение</returns>
        Task<bool> UpdateAsync(TUpdatableModel entity, CancellationToken cancellationToken);
    }
}
