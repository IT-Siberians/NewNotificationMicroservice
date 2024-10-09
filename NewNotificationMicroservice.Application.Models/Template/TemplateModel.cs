using NewNotificationMicroservice.Application.Models.Abstractions;
using NewNotificationMicroservice.Application.Models.Type;
using NewNotificationMicroservice.Application.Models.User;

namespace NewNotificationMicroservice.Application.Models.Template
{
    public record TemplateModel(
        Guid Id,
        string Language,
        string Template,
        bool IsRemoved,
        UserModel CreatedByUser,
        DateTime CreationDate,
        UserModel? ModifiedByUser,
        DateTime? ModificationDate,
        TypeModel Type) : IBaseModel<Guid>;
}