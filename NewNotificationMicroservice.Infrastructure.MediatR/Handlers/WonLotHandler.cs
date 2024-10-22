﻿using MediatR;
using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Models.Template;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using Otus.QueueDto.Email;
using Otus.QueueDto.Lot;
using System.Globalization;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class WonLotHandler(IProducerService<MessageEvent> sender, IBusQueueService queueService, ITemplateApplicationService templateService, IUserApplicationService userService, IMessageApplicationService messageService) : IRequestHandler<ConfirmationEmailCommand<WonLotEvent>, bool>
    {
        private readonly string _nameSite = "GoodDeal_OTUS";
        public async Task<bool> Handle(ConfirmationEmailCommand<WonLotEvent> request, CancellationToken cancellationToken)
        {
            var confirmationEmail = request.Message;

            var customer = await userService.GetByIdAsync(confirmationEmail.Customer, cancellationToken);

            if (customer is null)
            {
                return false;
            }

            var lang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo
                .GetCultures(CultureTypes.NeutralCultures)
                .FirstOrDefault(c => c.TwoLetterISOLanguageName.ToLower() == "Rus".ToLower())? // customer.Culture - надо добавить культуру пользоватлелю
                .ThreeLetterISOLanguageName ?? "Eng");

            var template = await GetTemplate(nameof(WonLotEvent), lang, cancellationToken);

            if (template is null)
            {
                return false;
            }

            var messageText = string.Format(template.Template, customer.Username, confirmationEmail.NameLot, _nameSite, confirmationEmail.Bid);
            var messageSend = new MessageEvent(customer.Username, customer.Email, template.Type.Name, messageText);

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