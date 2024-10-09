namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Информационное сообщение</param>
    internal class EmailInvalidException(string value)
        : FormatException(
            string.Format(
                "Email is not valid. Value is '{0}'.",
                value));
}
