using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.Type
{
    public record CreateTypeModel(
        string Name,
        Guid CreatedByUserId) : ICreateModel;
}
