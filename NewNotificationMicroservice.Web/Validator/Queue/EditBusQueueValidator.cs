using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.BusQueue;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Queue
{
    public class EditBusQueueValidator : AbstractValidator<EditBusQueueRequest>
    {
        public EditBusQueueValidator()
        {
            RuleFor(type => type.MessageTypeId)
                    .SetValidator(new GuidValidator());

            RuleFor(type => type.ModifiedByUserId)
                    .SetValidator(new GuidValidator());
        }
    }
}
