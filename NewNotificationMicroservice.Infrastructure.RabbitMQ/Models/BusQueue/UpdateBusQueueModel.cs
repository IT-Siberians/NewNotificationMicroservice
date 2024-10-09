using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.BusQueue
{
    public class UpdateBusQueueModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required Guid MessageTypeId { get; init; }
        public required bool IsRemoved { get; init; }
        public required Guid ModifiedByUserId { get; init; }
    }
}
