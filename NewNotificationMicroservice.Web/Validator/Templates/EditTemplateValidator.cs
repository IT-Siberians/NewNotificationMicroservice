using FluentValidation;
using NewNotificationMicroservice.Web.Contracts.Template;
using NewNotificationMicroservice.Web.Validator.Base;

namespace NewNotificationMicroservice.Web.Validator.Templates
{
    public class EditTemplateValidator : AbstractValidator<EditTemplateRequest>
    {
        public EditTemplateValidator()
        {

            RuleFor(template => template.MessageTypeId)
                .SetValidator(new GuidValidator());

            RuleFor(template => template.Language)
                .SetValidator(new LanguageValidatior());

            RuleFor(template => template.Template)
                .SetValidator(new TemplateValidator());

            RuleFor(template => template.ModifiedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
