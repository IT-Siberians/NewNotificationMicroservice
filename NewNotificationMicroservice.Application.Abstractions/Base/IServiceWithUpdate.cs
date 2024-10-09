using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Application.Services.Abstractions.Base.Parts;

namespace NewNotificationMicroservice.Application.Services.Abstractions.Base
{
    public interface IServiceWithUpdate<TModel, TCreatableModel, TUpdatableModel, TKey>
        : IService<TModel, TCreatableModel, TKey>,
        IUpdatableService<TUpdatableModel, TKey>
        where TModel : class, IBaseModel<TKey>
        where TCreatableModel : class, ICreateModel
        where TUpdatableModel : class, IBaseModel<TKey>
        where TKey : struct, IEquatable<TKey>;
}
