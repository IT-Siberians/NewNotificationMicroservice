using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.Template
{
    public record CreateTemplateModel(
        Guid MessageTypeId,
        string Language,
        string Template,
        Guid CreatedByUserId
        ) : ICreateModel;
}
