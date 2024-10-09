using FluentValidation;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Web.Validator.Base
{
    public class TemplateValidator : AbstractValidator<string>
    {
        public TemplateValidator()
        {
            RuleFor(request => request)
                .NotEmpty()
                .NotNull()
                .MinimumLength(Template.MinLength);
        }
    }
}
