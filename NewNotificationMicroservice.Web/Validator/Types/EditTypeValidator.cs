using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.Type;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Types
{
    public class EditTypeValidator : AbstractValidator<EditTypeRequest>
    {
        public EditTypeValidator()
        {
            RuleFor(type => type.Name)
                .SetValidator(new TypeNameValidator());

            RuleFor(type => type.ModifiedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
