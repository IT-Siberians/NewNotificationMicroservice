using NewNotificationMicroservice.Domain.ValueObjects.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects.Exceptions;

namespace NewNotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой шаблон уведомления.
    /// </summary>
    /// <param name="value">Значение шаблона.</param>
    /// <exception cref="TemplateNullOrEmptyException">Если значение шаблона пустое или null.</exception>
    /// <exception cref="TemplateLengthException">Если длина значения шаблона выходит за пределы допустимого диапазона.</exception>
    public class Template(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Минимальная длина названия для шаблона сообщения
        /// </summary>
        public const int MinLength = 30;

        /// <summary>
        /// Проверяет, является ли значение шаблона допустимым.
        /// </summary>
        /// <param name="value">Значение шаблона.</param>
        /// <exception cref="TemplateNullOrEmptyException">Если значение шаблона пустое или null.</exception>
        /// <exception cref="TemplateLengthException">Если длина значения шаблона выходит за пределы допустимого диапазона.</exception>
        protected override void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new TemplateNullOrEmptyException(value);
            }

            if (value.Length < MinLength)
            {
                throw new TemplateLengthException(MinLength, value.Length.ToString());
            }
        }
    }
}
