namespace NewNotificationMicroservice.Common.Infrastructure.Queues.Events
{
    public record CreateUserEvent(
        Guid Id,
        string Username,
        string FullName,
        string Email);
}
