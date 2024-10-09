using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.Type
{
    public class UpdateTypeModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required string Name { get; init; } = string.Empty;
        public required Guid ModifiedByUserId { get; init; }
    }
}
