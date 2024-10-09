using AutoMapper;
using NewNotificationMicroservice.Application.Models.Type;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.Repositories.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Application.Services
{
    public class MessageTypeService(IMessageTypeRepository messageTypeRepository, IUserRepository userRepository, IMapper mapper) : ITypeApplicationService
    {

        public async Task<IEnumerable<TypeModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var dbEntities = await messageTypeRepository.GetAllAsync(cancellationToken, true);

            return dbEntities.Select(mapper.Map<TypeModel>);
        }

        public async Task<TypeModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbEntity = await messageTypeRepository.GetByIdAsync(id, cancellationToken);

            return dbEntity is null ? null : mapper.Map<TypeModel>(dbEntity);
        }

        public async Task<Guid?> AddAsync(CreateTypeModel type, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(type.CreatedByUserId, cancellationToken);

            if (user is null)
            {
                return null;
            }

            var typeNew = new MessageType(new TypeName(type.Name), false, user, DateTime.UtcNow, null, null);

            return await messageTypeRepository.AddAsync(typeNew, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateTypeModel messageType, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageType.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var type = await messageTypeRepository.GetByIdAsync(messageType.Id, cancellationToken);

            if (type is null || type.IsRemoved)
            {
                return false;
            }

            type.Update(new TypeName(messageType.Name), false, user, DateTime.UtcNow);

            return await messageTypeRepository.UpdateAsync(type, cancellationToken);
        }

        public async Task<bool> DeleteAsync(DeleteTypeModel messageType, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageType.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var type = await messageTypeRepository.GetByIdAsync(messageType.Id, cancellationToken);

            if (type is null)
            {
                return false;
            }

            type.Delete(user, DateTime.UtcNow);

            return await messageTypeRepository.DeleteAsync(type, cancellationToken);
        }
    }
}
