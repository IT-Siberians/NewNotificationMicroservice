namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class TypeNameNullOrEmptyException(string value)
        : ArgumentNullException(
            value,
            "Type Name cannot be empty.");
}
