using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Services.Abstractions.Base.Parts
{
    public interface IGetableService<TModel, TKey>
        where TModel : class, IBaseModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Получает все сущности из источника данных.
        /// </summary>
        /// <returns>Список всех сущностей типа <typeparamref name="TModel"/>.</returns>
        Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность типа <typeparamref name="TModel"/> с указанным идентификатором или <c>null</c>, если сущность не найдена.</returns>
        Task<TModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
