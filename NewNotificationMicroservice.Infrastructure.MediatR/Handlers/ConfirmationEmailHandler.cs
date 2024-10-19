using MediatR;
using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Models.Template;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using Otus.QueueDto.Email;
using Otus.QueueDto.Notification;
using System.Globalization;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class ConfirmationEmailHandler(IProducerService<MessageEvent> sender, IBusQueueService queueService, ITemplateApplicationService templateService, IMessageApplicationService messageService) : IRequestHandler<ConfirmationEmailCommand<ConfirmationEmailEvent>, bool>
    {
        private readonly string _nameSite = "GoodDeal_OTUS";

        public async Task<bool> Handle(ConfirmationEmailCommand<ConfirmationEmailEvent> request, CancellationToken cancellationToken)
        {
            var confirmationEmail = request.Message;

            var lang = CultureInfo
                .GetCultures(CultureTypes.NeutralCultures)
                .FirstOrDefault(c => c.TwoLetterISOLanguageName.ToLower() == confirmationEmail.Email.ToLower())?
                .ThreeLetterWindowsLanguageName ?? "Eng";

            var template = await GetTemplate(nameof(ConfirmationEmailEvent), lang, cancellationToken);

            if (template is null)
            {
                return false;
            }

            var messageText = string.Format(template.Template, confirmationEmail.Username, confirmationEmail.Link, _nameSite);
            var messageSend = new MessageEvent(confirmationEmail.Username, confirmationEmail.Email, template.Type.Name, messageText);

            sender.Send(messageSend, Direction.Email);

            var messageSave = new CreateMessageModel(template.Type.Id, messageText, Direction.Email);
            await messageService.AddAsync(messageSave, cancellationToken);

            return true;
        }

        private async Task<TemplateModel?> GetTemplate(string queue, string lang, CancellationToken cancellationToken)
        {
            var queueDb = await queueService.GetByNameAsync(queue, cancellationToken);

            return queueDb is null ? null : await templateService.GetByQueueAndLanguageAsync(queueDb.Type.Id, lang, cancellationToken);
        }
    }
}
