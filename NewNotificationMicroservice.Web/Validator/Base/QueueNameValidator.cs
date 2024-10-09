using FluentValidation;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.ValueObject;

namespace NewNotificationMicroservice.Web.Validator.Base
{
    public class QueueNameValidator : AbstractValidator<string>
    {
        public QueueNameValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .Matches(QueueName.Regex)
                .Length(QueueName.MixLength, QueueName.MaxLength);
        }
    }
}
