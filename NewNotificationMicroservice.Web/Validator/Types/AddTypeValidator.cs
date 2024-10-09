using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.Type;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Types
{
    public class AddTypeValidator : AbstractValidator<AddTypeRequest>
    {
        public AddTypeValidator()
        {
            RuleFor(type => type.Name)
                .SetValidator(new TypeNameValidator());

            RuleFor(type => type.CreatedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
