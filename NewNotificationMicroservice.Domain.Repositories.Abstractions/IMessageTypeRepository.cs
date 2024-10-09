using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.Repositories.Abstractions.Base;

namespace NewNotificationMicroservice.Domain.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для управления объектами типа <see cref="MessageType"/>.
    /// </summary>
    public interface IMessageTypeRepository : IRepositoryWithUpdateAndDelete<MessageType, Guid>;
}
