namespace NewNotificationMicroservice.Web.Contracts.BusQueue
{
    public record AddBusQueueRequest(
        string QueueName,
        Guid MessageTypeId,
        Guid CreatedByUserId);
}
