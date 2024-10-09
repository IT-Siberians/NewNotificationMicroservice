using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Domain.Entities.Enums;

namespace NewNotificationMicroservice.Application.Models.Message
{
    public record CreateMessageModel(
        Guid MessageTypeId,
        string MessageText,
        Direction Direction) : ICreateModel;
}
