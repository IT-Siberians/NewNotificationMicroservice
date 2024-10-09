using NewNotificationMicroservice.Domain.ValueObjects.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects.Exceptions;

namespace NewNotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для ФИО пользователя (FullName).
    /// </summary>
    /// <param name="value">Строковое значение ФИО пользователя.</param>
    /// <exception cref="NameEmptyException">Возникает, когда значение ФИО пользователя является null, пустой строкой или состоит только из пробелов.</exception>
    /// <exception cref="NameLengthException">Возникает, когда длина значения ФИО пользователя не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
    public class FullName(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Минимальная длина FullName
        /// </summary>
        public const int MinLength = 5;

        /// <summary>
        /// Максимальная длина FullName
        /// </summary>
        public const int MaxLength = 100;

        /// <summary>
        /// Проверяет, является ли значение ФИО пользователя валидным.
        /// </summary>
        /// <param name="value">Значение ФИО пользователя для проверки.</param>
        /// <exception cref="NameEmptyException">Возникает, когда значение ФИО пользователя является null, пустой строкой или состоит только из пробелов.</exception>
        /// <exception cref="NameLengthException">Возникает, когда длина значения ФИО пользователя не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
        protected override void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NameEmptyException(nameof(value));
            }

            if (value.Length < MinLength || value.Length > MaxLength)
            {
                throw new NameLengthException(value.Length, MinLength, MaxLength, nameof(value));
            }
        }
    }
}
