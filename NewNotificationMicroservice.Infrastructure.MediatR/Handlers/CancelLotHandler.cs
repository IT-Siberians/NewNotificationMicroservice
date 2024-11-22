using MediatR;
using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Models.Template;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using Otus.QueueDto.Email;
using Otus.QueueDto.Lot;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class CancelLotHandler(IProducerService<MessageEvent> sender, IBusQueueService queueService, ITemplateApplicationService templateService, IUserApplicationService userService, IMessageApplicationService messageService) : IRequestHandler<CancelLotCommand<CancelLotEvent>, bool>
    {
        private readonly string _nameSite = "GoodDeal_OTUS";
        public async Task<bool> Handle(CancelLotCommand<CancelLotEvent> request, CancellationToken cancellationToken)
        {
            var cancelLot = request.Message;

            var seller = await userService.GetByIdAsync(cancelLot.SellerId, cancellationToken);

            if (seller is null)
            {
                return false;
            }

            var template = await GetTemplate(nameof(CancelLotEvent), seller.Language, cancellationToken);

            if (template is null)
            {
                return false;
            }

            var messageText = string.Format(template.Template, seller.FullName, cancelLot.Title, _nameSite);
            var messageSend = new MessageEvent(seller.Username, seller.Email, template.Type.Name, messageText);

            sender.Send(messageSend, Direction.Email);

            var messageSave = new CreateMessageModel(template.Type.Id, messageText, Direction.Email);
            await messageService.AddAsync(messageSave, cancellationToken);

            return true;
        }

        private async Task<TemplateModel?> GetTemplate(string queue, string lang, CancellationToken cancellationToken)
        {
            var queueDb = await queueService.GetByNameAsync(queue, cancellationToken);

            if (queueDb is null)
            {
                return null;
            }

            var template = await templateService.GetByQueueAndLanguageAsync(queueDb.Type.Id, lang, cancellationToken);

            return template is not null ? template : await templateService.GetByQueueAndLanguageAsync(queueDb.Type.Id, "Eng", cancellationToken);
        }
    }
}
