using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.BusQueue;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Queue
{
    public class DeleteBusQueueValidator : AbstractValidator<DeleteBusQueueRequest>
    {
        public DeleteBusQueueValidator()
        {
            RuleFor(type => type.ModifiedByUserId)
                    .SetValidator(new GuidValidator());
        }
    }
}
