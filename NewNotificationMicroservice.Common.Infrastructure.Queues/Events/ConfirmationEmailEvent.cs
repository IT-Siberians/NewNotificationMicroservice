namespace NewNotificationMicroservice.Common.Infrastructure.Queues.Events
{
    public record ConfirmationEmailEvent(
        string Email,
        string Username,
        Uri Link);
}
