namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="lengthMin">Значение минимальной длинны</param>
    /// <param name="lengthMax">Значение максимальной длинны</param>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class TypeNameLengthException(int lengthMin, int lengthMax, string value)
        : ArgumentOutOfRangeException(
            value,
            string.Format(
                "The length of the message type name is invalid. It should be between '{0}' and '{1}' characters long.",
                lengthMin,
                lengthMax));
}
