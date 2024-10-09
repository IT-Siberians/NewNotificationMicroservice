using NewNotificationMicroservice.Domain.ValueObjects.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects.Exceptions;

namespace NewNotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для имени типа (TypeName).
    /// </summary>
    /// <param name="value">Строковое значение имени типа.</param>
    /// <exception cref="TypeNameNullOrEmptyException">Возникает, когда значение имени типа является null или пустой строкой.</exception>
    /// <exception cref="TypeNameLengthException">Возникает, когда длина имени типа не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
    public class TypeName(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Минимальная длина названия для типа сообщения
        /// </summary>
        public const int MinLength = 20;

        /// <summary>
        /// Максимальная длина названия для типа сообщения
        /// </summary>
        public const int MaxLength = 50;

        /// <summary>
        /// Валидация входных данных. Проверяет, что имя типа не является null или пустой строкой и соответствует заданным ограничениям на длину.
        /// </summary>
        /// <param name="name">Название типа сообщения для проверки.</param>
        /// <exception cref="TypeNameNullOrEmptyException">Возникает, когда значение имени типа является null или пустой строкой.</exception>
        /// <exception cref="MessageTypeNameLengthException">Возникает, когда длина имени типа не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
        protected override void IsValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new TypeNameNullOrEmptyException(name);
            }

            if (name.Length < MinLength || name.Length > MaxLength)
            {
                throw new TypeNameLengthException(MinLength, MaxLength, name.Length.ToString());
            }
        }
    }
}
