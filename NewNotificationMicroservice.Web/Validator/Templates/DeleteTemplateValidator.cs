using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.Template;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Templates
{
    public class DeleteTemplateValidator : AbstractValidator<DeleteTemplateRequest>
    {
        public DeleteTemplateValidator()
        {
            RuleFor(template => template.ModifiedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
