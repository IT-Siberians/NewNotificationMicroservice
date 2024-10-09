using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Web.Contracts.Type;

namespace NewNotificationMicroservice.Web.Contracts.Message
{
    public record MessageResponse(
        Guid Id,
        TypeResponse Type,
        string Text,
        Direction Direction,
        DateTime CreationDate);
}
