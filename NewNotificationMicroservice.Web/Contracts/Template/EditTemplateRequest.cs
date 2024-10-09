namespace NewNotificationMicroservice.Web.Contracts.Template
{
    public record EditTemplateRequest(
        Guid MessageTypeId,
        string Language,
        string Template,
        Guid ModifiedByUserId);
}
