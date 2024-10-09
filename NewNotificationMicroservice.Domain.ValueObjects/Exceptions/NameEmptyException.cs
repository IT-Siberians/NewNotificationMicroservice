namespace NewNotificationMicroservice.Domain.ValueObjects.Exceptions
{
    /// <summary>
    /// Исключительная ситуация создание пустого Имени пользователя
    /// </summary>
    /// <param name="paramName">Название параметра, в котором произошло исключение</param>
    internal class NameEmptyException(string paramName)
        : ArgumentNullException(
            paramName,
            "{0} cannot null or empty.");
}
