using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.User
{
    public record UpdateUserModel(
        Guid Id,
        string FullName,
        string Email) : IBaseModel<Guid>;
}
