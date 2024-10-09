namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class MessageTextNullOrEmptyException(string value)
        : ArgumentNullException(
            value,
            "Message text cannot be empty.");
}
