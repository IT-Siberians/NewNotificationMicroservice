using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Application.Services.Abstractions.Base;

namespace NewNotificationMicroservice.Application.Services.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с пользователями
    /// </summary>
    public interface IUserApplicationService : IServiceWithUpdate<UserModel, CreateUserModel, UpdateUserModel, Guid>;
}
