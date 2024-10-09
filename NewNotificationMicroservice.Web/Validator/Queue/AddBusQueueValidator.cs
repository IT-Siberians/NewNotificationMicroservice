using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.BusQueue;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Queue
{
    public class AddBusQueueValidator : AbstractValidator<AddBusQueueRequest>
    {
        public AddBusQueueValidator()
        {

            RuleFor(type => type.QueueName)
                .SetValidator(new QueueNameValidator());

            RuleFor(type => type.MessageTypeId)
                .SetValidator(new GuidValidator());

            RuleFor(type => type.CreatedByUserId)
                    .SetValidator(new GuidValidator());
        }
    }
}
