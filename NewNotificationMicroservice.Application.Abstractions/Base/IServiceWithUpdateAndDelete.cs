using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Application.Services.Abstractions.Base.Parts;

namespace NewNotificationMicroservice.Application.Services.Abstractions.Base
{
    /// <summary>
    /// Интерфейс для сервисов с возможностью изменения сущностей
    /// </summary>
    /// <typeparam name="TModel">Сущность</typeparam>
    /// <typeparam name="TCreatableModel">Модель для создания</typeparam>
    /// <typeparam name="TUpdatableModel">Модель для изменения</typeparam>
    /// <typeparam name="TDeletableModel">Модель для удаления</typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IServiceWithUpdateAndDelete<TModel, TCreatableModel, TUpdatableModel, TDeletableModel, TKey>
        : IServiceWithUpdate<TModel, TCreatableModel, TUpdatableModel, TKey>,
        IDeletableService<TDeletableModel, TKey>
        where TModel : class, IBaseModel<TKey>
        where TCreatableModel : class, ICreateModel
        where TUpdatableModel : class, IBaseModel<TKey>
        where TDeletableModel : class, IBaseModel<TKey>
        where TKey : struct, IEquatable<TKey>;
}
