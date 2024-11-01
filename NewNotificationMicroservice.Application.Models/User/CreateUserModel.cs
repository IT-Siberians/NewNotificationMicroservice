using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.User
{
    public record CreateUserModel(
        Guid Id,
        string Username,
        string FullName,
        string Email,
        string Language) : ICreateModel;
}
