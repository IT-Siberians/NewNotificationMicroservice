using NewNotificationMicroservice.Web.Contracts.Type;

namespace NewNotificationMicroservice.Web.Contracts.BusQueue
{
    public record BusQueueResponse(
        Guid Id,
        string QueueName,
        TypeResponse Type,
        bool IsRemoved,
        Guid CreatedByUserId,
        DateTime CreationDate,
        Guid? ModifiedByUserId,
        DateTime? ModificationDate);
}
