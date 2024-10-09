using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Services.Abstractions.Base;

namespace NewNotificationMicroservice.Application.Services.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с сообщениями
    /// </summary>
    public interface IMessageApplicationService : IService<MessageModel, CreateMessageModel, Guid>;
}
