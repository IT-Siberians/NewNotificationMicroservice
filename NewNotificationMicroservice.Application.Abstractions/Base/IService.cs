using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Application.Services.Abstractions.Base.Parts;

namespace NewNotificationMicroservice.Application.Services.Abstractions.Base
{
    /// <summary>
    /// Интерфейс для сервисов, обеспечивающих базовые операции с сущностями.
    /// </summary>
    /// <typeparam name="TModel">Тип сущности, с которой производится работа.</typeparam>
    /// <typeparam name="TCreatableModel">Тип сущности, используемый для создания новых записей.</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности.</typeparam>
    public interface IService<TModel, TCreatableModel, TKey>
        : IGetableService<TModel, TKey>,
        IAddableService<TCreatableModel, TKey>
        where TModel : class, IBaseModel<TKey>
        where TCreatableModel : class, ICreateModel
        where TKey : struct, IEquatable<TKey>;
}
