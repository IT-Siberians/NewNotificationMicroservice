using FluentValidation;

namespace NewNotificationMicroservice.Web.Validator.Base
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotEmpty();
        }
    }
}
