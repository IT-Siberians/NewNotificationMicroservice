using NewNotificationMicroservice.Domain.ValueObjects.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects.Exceptions;

namespace NewNotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для имени пользователя (username).
    /// </summary>
    /// <param name="value">Значение имени пользователя.</param>
    /// <exception cref="NameEmptyException">Если значение имени пользователя пустое или состоит только из пробелов.</exception>
    /// <exception cref="NameLengthException">Если длина значения имени пользователя выходит за пределы допустимого диапазона.</exception>
    public class Username(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Минимальная длина Username
        /// </summary>
        public const int MinLength = 3;

        /// <summary>
        /// Максимальная длина Username
        /// </summary>
        public const int MaxLength = 30;

        /// <summary>
        /// Проверяет, является ли значение имени пользователя валидным.
        /// </summary>
        /// <param name="value">Значение имени пользователя для проверки.</param>
        /// <exception cref="NameEmptyException">Если значение имени пользователя пустое или состоит только из пробелов.</exception>
        /// <exception cref="NameLengthException">Если длина значения имени пользователя выходит за пределы допустимого диапазона.</exception>
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
