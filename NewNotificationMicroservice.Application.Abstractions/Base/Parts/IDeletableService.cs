using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Services.Abstractions.Base.Parts
{
    public interface IDeletableService<TDeletableModel, TKey>
        where TDeletableModel : class, IBaseModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Мягкое удаление сущности
        /// </summary>
        /// <param name="entity">Модель для изменения</param>
        /// <returns>Булевое значение</returns>
        Task<bool> DeleteAsync(TDeletableModel entity, CancellationToken cancellationToken);
    }
}
