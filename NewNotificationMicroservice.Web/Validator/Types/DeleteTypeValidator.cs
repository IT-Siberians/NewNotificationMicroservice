using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.Type;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Types
{
    public class DeleteTypeValidator : AbstractValidator<DeleteTypeRequest>
    {
        public DeleteTypeValidator()
        {
            RuleFor(type => type.ModifiedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
