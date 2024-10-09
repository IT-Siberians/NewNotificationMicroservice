using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Application.Models.Type;
using NewNotificationMicroservice.Application.Models.User;

namespace NewNotificationMicroservice.Application.Models.BusQueue
{
    public record BusQueueModel(
        Guid Id,
        string QueueName,
        TypeModel Type,
        bool IsRemoved,
        UserModel CreatedByUser,
        DateTime CreationDate,
        UserModel? ModifiedByUser,
        DateTime? ModificationDate) : IBaseModel<Guid>;
}
