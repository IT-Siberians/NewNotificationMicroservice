using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.BusQueue
{
    public record CreateBusQueueModel(
        string QueueName,
        Guid MessageTypeId,
        Guid CreatedByUserId) : ICreateModel;
}
