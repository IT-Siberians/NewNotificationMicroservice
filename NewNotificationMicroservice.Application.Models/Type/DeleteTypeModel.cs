using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.Type
{
    public class DeleteTypeModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required Guid ModifiedByUserId { get; init; }
    }
}
