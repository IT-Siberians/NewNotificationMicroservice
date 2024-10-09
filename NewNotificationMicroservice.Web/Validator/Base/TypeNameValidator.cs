using FluentValidation;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Web.Validator.Base
{
    public class TypeNameValidator : AbstractValidator<string>
    {
        public TypeNameValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .Length(TypeName.MinLength, TypeName.MaxLength);
        }
    }
}
