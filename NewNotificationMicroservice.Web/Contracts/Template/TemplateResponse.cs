using NewNotificationMicroservice.Web.Contracts.Type;

namespace NewNotificationMicroservice.Web.Contracts.Template
{
    public record TemplateResponse(
        Guid Id,
        TypeResponse Type,
        string Language,
        string Template,
        bool IsRemoved,
        Guid CreatedByUserId,
        DateTime CreationDate,
        Guid? ModifiedByUserId,
        DateTime? ModificationDate);
}
