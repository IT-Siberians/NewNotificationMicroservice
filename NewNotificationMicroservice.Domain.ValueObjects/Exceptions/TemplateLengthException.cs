namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="lengthMin">Значение минимальной длинны</param>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class TemplateLengthException(int lengthMin, string value)
        : ArgumentOutOfRangeException(
            value,
            string.Format(
                "The length of the message template is invalid. It should be longer than the minimal '{0}' allowed value.",
                lengthMin));
}
