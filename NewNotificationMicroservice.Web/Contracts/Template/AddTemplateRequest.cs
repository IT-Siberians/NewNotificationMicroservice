namespace NewNotificationMicroservice.Web.Contracts.Template
{
    public record AddTemplateRequest(
        Guid MessageTypeId,
        string Language,
        string Template,
        Guid CreatedByUserId);
}
