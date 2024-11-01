using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.User
{
    public record UpdateUserModel(
        Guid Id,
        string FullName,
        string Email,
        string Language) : IBaseModel<Guid>;
}
