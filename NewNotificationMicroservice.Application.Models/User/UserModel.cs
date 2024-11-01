using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.User
{
    public record UserModel(
        Guid Id,
        string Username,
        string FullName,
        string Email,
        string Language,
        DateTime CreationDate) : IBaseModel<Guid>;
}
