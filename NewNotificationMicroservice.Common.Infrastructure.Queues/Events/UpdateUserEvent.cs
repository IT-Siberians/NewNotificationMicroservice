namespace NewNotificationMicroservice.Common.Infrastructure.Queues.Events
{
    public record UpdateUserEvent(
        Guid Id,
        string FullName,
        string Email);
}
