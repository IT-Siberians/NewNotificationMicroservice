namespace NewNotificationMicroservice.Web.Contracts.BusQueue
{
    public record EditBusQueueRequest(
        Guid MessageTypeId,
        bool IsRemoved,
        Guid ModifiedByUserId);
}
