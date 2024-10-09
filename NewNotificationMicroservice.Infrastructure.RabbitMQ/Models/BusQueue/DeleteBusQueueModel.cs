using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.BusQueue
{
    public class DeleteBusQueueModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required Guid ModifiedByUserId { get; set; }
    }
}
