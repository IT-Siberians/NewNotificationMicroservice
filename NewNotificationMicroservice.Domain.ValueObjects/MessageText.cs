using NewNotificationMicroservice.Domain.ValueObjects.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects.Exceptions;

namespace NewNotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет текст сообщения и обеспечивает проверку его корректности.
    /// </summary>
    /// <param name="value">Строка, представляющая текст сообщения.</param>
    /// <exception cref="MessageTextNullOrEmptyException">Выбрасывается, если значение текста сообщения пустое или null.</exception>
    public class MessageText(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Проверяет, является ли значение текста сообщения валидным.
        /// </summary>
        /// <param name="value">Значение текста сообщения.</param>
        /// <exception cref="MessageTextNullOrEmptyException">Выбрасывается, если значение текста сообщения пустое или null.</exception>
        protected override void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new MessageTextNullOrEmptyException(value);
            }
        }
    }
}
