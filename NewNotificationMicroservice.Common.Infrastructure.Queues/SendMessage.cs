namespace NewNotificationMicroservice.Common.Infrastructure.Queues
{
    public record SendMessage(
        string Name,
        string Email,
        string MessageType,
        string MessageText);
}
