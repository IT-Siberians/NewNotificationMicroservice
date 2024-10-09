namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключительная ситуация создание Имени пользователя длиннее допустимого
    /// </summary>
    /// <param name="valueLength">Длина Имени пользователя</param>
    /// <param name="lengthMin">Значение минимальной длинны</param>
    /// <param name="lengthMax">Значение максимальной длинны</param>
    /// <param name="paramName">Название параметра, в котором произошло исключение</param>
    internal class NameLengthException(int valueLength, int lengthMin, int lengthMax, string paramName)
        : ArgumentOutOfRangeException(
            paramName,
            string.Format(
                "The {0} is longer than the allowed length of the {0}. It should be between '{1}' and '{2}' characters long. Current value '{3}'",
                paramName,
                lengthMin,
                lengthMax,
                valueLength));
}
