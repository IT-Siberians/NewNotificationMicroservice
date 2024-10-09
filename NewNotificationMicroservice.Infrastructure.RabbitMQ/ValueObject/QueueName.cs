using NewNotificationMicroservice.Domain.ValueObjects.Abstractions;
using System.Text.RegularExpressions;

namespace NewNotificationMicroservice.Infrastructure.RabbitMQ.ValueObject
{
    public class QueueName(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Минимальная длина QueueName
        /// </summary>
        public const int MixLength = 5;

        /// <summary>
        /// Максимальная длина QueueName
        /// </summary>
        public const int MaxLength = 30;

        /// <summary>
        /// Регулярное выражение проверки имени очереди
        /// </summary>
        public const string Regex = @"^[A-Za-z0-9]+$";

        private static readonly Regex ValidationRegex = new Regex(
            Regex,
            RegexOptions.Singleline | RegexOptions.Compiled);

        protected override void IsValid(string value)
        {
            if (!(!string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value)))
            {
                throw new FormatException(string.Format("QueueName is not valid. Value is '{0}'.", value));
            }

            if (value.Length < MixLength || value.Length > MaxLength)
            {
                throw new ArgumentOutOfRangeException(
                    value,
                    string.Format(
                        "The {0} of the queue name is invalid. It should be between '{1}' and '{2}' characters long. Current value '{3}.'",
                        nameof(value),
                        MixLength,
                        MaxLength,
                        value.Length));
            }
        }
    }
}