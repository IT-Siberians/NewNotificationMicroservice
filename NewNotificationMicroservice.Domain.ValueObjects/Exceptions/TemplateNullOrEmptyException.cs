namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    public class TemplateNullOrEmptyException(string value)
        : ArgumentNullException(
            value,
            "Template cannot be empty.");
}