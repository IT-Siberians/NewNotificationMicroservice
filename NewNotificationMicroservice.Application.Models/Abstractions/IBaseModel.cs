namespace NewNotificationMicroservice.Application.Models.Abstractions
{
    public interface IBaseModel<TKey> where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
