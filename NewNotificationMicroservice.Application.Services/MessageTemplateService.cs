using AutoMapper;
using NewNotificationMicroservice.Application.Models.Template;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Domain.Entities;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Domain.Repositories.Abstractions;
using NewNotificationMicroservice.Domain.ValueObjects;

namespace NewNotificationMicroservice.Application.Services
{
    public class MessageTemplateService(IMessageTemplateRepository templateRepository, IMessageTypeRepository typeRepository, IUserRepository userRepository, IMapper mapper) : ITemplateApplicationService
    {
        public async Task<IEnumerable<TemplateModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var dbEntities = await templateRepository.GetAllAsync(cancellationToken, true);

            return dbEntities.Select(mapper.Map<TemplateModel>);
        }

        public async Task<TemplateModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbEntity = await templateRepository.GetByIdAsync(id, cancellationToken);

            return dbEntity is null ? null : mapper.Map<TemplateModel>(dbEntity);
        }

        public async Task<IEnumerable<TemplateModel>> GetByTypeIdAsync(Guid typeId, CancellationToken cancellationToken = default)
        {
            var dbEntities = await templateRepository.GetByTypeIdAsync(typeId, cancellationToken);

            return dbEntities.Select(mapper.Map<TemplateModel>);
        }

        public async Task<TemplateModel?> GetByQueueAndLanguageAsync(Guid typeId, string language, CancellationToken cancellationToken = default)
        {
            var dbEntity = await templateRepository.GetByQueueAndLanguageAsync(typeId, (Language)Enum.Parse(typeof(Language), language), cancellationToken);

            return dbEntity is null ? null : mapper.Map<TemplateModel>(dbEntity);
        }

        public async Task<Guid?> AddAsync(CreateTemplateModel messageTemplate, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.CreatedByUserId, cancellationToken);

            if (user is null)
            {
                return null;
            }

            var type = await typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, cancellationToken);

            if (type is null || type.IsRemoved)
            {
                return null;
            }

            var template = new MessageTemplate(type, (Language)Enum.Parse(typeof(Language), messageTemplate.Language), new Template(messageTemplate.Template), false, user, DateTime.UtcNow, null, null);

            return await templateRepository.AddAsync(template, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateTemplateModel messageTemplate, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var type = await typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, cancellationToken);

            if (type is null || type.IsRemoved)
            {
                return false;
            }

            var template = await templateRepository.GetByIdAsync(messageTemplate.Id, cancellationToken);

            if (template is null)
            {
                return false;
            }

            template.Update(type, (Language)Enum.Parse(typeof(Language), messageTemplate.Language), new Template(messageTemplate.Template), messageTemplate.IsRemoved, user, DateTime.UtcNow);

            return await templateRepository.UpdateAsync(template, cancellationToken);
        }

        public async Task<bool> DeleteAsync(DeleteTemplateModel messageTemplate, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var template = await templateRepository.GetByIdAsync(messageTemplate.Id, cancellationToken);

            if (template is null)
            {
                return false;
            }

            template.Delete(user, DateTime.UtcNow);

            return await templateRepository.DeleteAsync(template, cancellationToken);
        }
    }
}
