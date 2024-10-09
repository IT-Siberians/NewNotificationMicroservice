using FluentValidation;
using NewNotificationMicroservice.Domain.Entities.Enums;

namespace NewNotificationMicroservice.Web.Validator.Base
{
    public class LanguageValidatior : AbstractValidator<string>
    {
        public LanguageValidatior()
        {
            RuleFor(request => request)
                .NotEmpty()
                .NotNull()
                .Must(BeAValidLanguage);
        }

        private bool BeAValidLanguage(string request)
        {
            return Enum.GetNames(typeof(Language))
                .Any(x => x.Equals(request, StringComparison.Ordinal));
        }
    }
}
