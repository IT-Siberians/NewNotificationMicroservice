using NewNotificationMicroservice.Application.Models.Type;
using NewNotificationMicroservice.Application.Services.Abstractions.Base;

namespace NewNotificationMicroservice.Application.Services.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с типами
    /// </summary>
    public interface ITypeApplicationService : IServiceWithUpdateAndDelete<TypeModel, CreateTypeModel, UpdateTypeModel, DeleteTypeModel, Guid>;
}
