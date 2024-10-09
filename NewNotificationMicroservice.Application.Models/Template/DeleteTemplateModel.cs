using NewNotificationMicroservice.Application.Models.Abstractions;

namespace NewNotificationMicroservice.Application.Models.Template
{
    public class DeleteTemplateModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required Guid ModifiedByUserId { get; init; }
    }
}
