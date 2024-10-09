using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Application.Models.Type;
using NewNotificationMicroservice.Domain.Entities.Enums;

namespace NewNotificationMicroservice.Application.Models.Message
{
    public record MessageModel(
        Guid Id,
        string Text,
        Direction Direction,
        DateTime CreationDate,
        TypeModel Type) : IBaseModel<Guid>;
}
