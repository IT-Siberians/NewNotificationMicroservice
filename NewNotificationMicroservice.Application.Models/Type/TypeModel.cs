using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Application.Models.User;

namespace NewNotificationMicroservice.Application.Models.Type
{
    public record TypeModel(
        Guid Id,
        string Name,
        bool IsRemoved,
        UserModel CreatedByUser,
        DateTime CreationDate,
        UserModel? ModifiedByUser,
        DateTime? ModificationDate) : IBaseModel<Guid>;
}
