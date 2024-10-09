namespace NewNotificationMicroservice.Web.Contracts.Type
{
    public record EditTypeRequest(
        string Name,
        Guid ModifiedByUserId);
}
