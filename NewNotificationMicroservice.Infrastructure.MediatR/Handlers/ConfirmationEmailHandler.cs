using MediatR;
using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Models.Template;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Common.Infrastructure.Queues;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Events;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using System.Globalization;
using System.Text.Json;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class ConfirmationEmailHandler(IProducerService sender, IBusQueueService queueService, ITemplateApplicationService templateService, IMessageApplicationService messageService) : IRequestHandler<ConfirmationEmailCommand, bool>
    {
        private readonly string _nameSite = "GoodDeal_OTUS";
        private readonly string _lang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.ThreeLetterISOLanguageName);

        public async Task<bool> Handle(ConfirmationEmailCommand request, CancellationToken cancellationToken)
        {
            var template = await GetTemplate("ConfirmationEmail", cancellationToken);

            if (template is null)
            {
                return false;
            }

            var confirmationEmail = JsonSerializer.Deserialize<ConfirmationEmailEvent>(request.Message);
            var messageText = string.Format(template.Template, confirmationEmail.Username, confirmationEmail.Link, _nameSite);
            var messageSend = new SendMessage(confirmationEmail.Username, confirmationEmail.Email, template.Type.Name, messageText);

            sender.SendMessage(messageSend, Direction.Email);

            var messageSave = new CreateMessageModel(template.Type.Id, messageText, Direction.Email);
            await messageService.AddAsync(messageSave, cancellationToken);

            return true;
        }

        private async Task<TemplateModel?> GetTemplate(string queue, CancellationToken cancellationToken)
        {
            var queueDb = await queueService.GetByNameAsync(queue, cancellationToken);

            return queueDb is null ? null : await templateService.GetByQueueAndLanguageAsync(queueDb.Type.Id, _lang, cancellationToken);
        }
    }
}
