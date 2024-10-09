namespace NewNotificationMicroservice.Web.Contracts.Type
{
    public record AddTypeRequest(
        string Name,
        Guid CreatedByUserId);
}
