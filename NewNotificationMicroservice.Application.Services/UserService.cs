using AutoMapper;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Domain.Repositories.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Application.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserApplicationService
    {
        public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await userRepository.GetAllAsync(cancellationToken, true);

            return users.Select(mapper.Map<UserModel>);
        }

        public async Task<UserModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken);

            return user is null ? null : mapper.Map<UserModel>(user);
        }

        public async Task<Guid?> AddAsync(CreateUserModel createUser, CancellationToken cancellationToken = default)
        {

            var user = await userRepository.GetByIdAsync(createUser.Id, cancellationToken);

            if (user is not null)
            {
                return null;
            }

            var newUser = new User(createUser.Id, new Username(createUser.Username), new FullName(createUser.FullName), new Email(createUser.Email), GetLanguage(createUser.Language));

            return await userRepository.AddAsync(newUser, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateUserModel updateUser, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(updateUser.Id, cancellationToken);

            if (user == null)
            {
                return false;
            }

            user.Update(new FullName(updateUser.FullName), new Email(updateUser.Email), GetLanguage(updateUser.Language));

            return await userRepository.UpdateAsync(user, cancellationToken);
        }

        private Language GetLanguage(string language)
        {
            if (string.IsNullOrWhiteSpace(language))
            {
                return (Language)Enum.Parse(typeof(Language), "Rus");
            }
            return (Language)Enum.Parse(typeof(Language), language);
        }
    }
}
