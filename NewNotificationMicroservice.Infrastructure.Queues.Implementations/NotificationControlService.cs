using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Common.Infrastructure.Queues;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Abstraction;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Events;
using NewNotificationMicroservice.Domain.Entities.Enums;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Abstraction;
using System.Globalization;
using System.Text.Json;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations
{
    public class NotificationControlService(IProducerService sender, ITemplateApplicationService templateService, IMessageApplicationService messageService, IBusQueueService queueService, IUserApplicationService userService)
    {
        private readonly string _nameSite = "GoodDeal_OTUS";
        private readonly string _lang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.ThreeLetterISOLanguageName);

        public async Task<bool> WorckAsync(string message, string queue, CancellationToken cancellationToken)
        {
            switch (queue)
            {
                case "ConfirmationEmail":

                    var queueDb = await queueService.GetByNameAsync(queue, cancellationToken);

                    if (queueDb is null)
                    {
                        return false;
                    }

                    var template = await templateService.GetByQueueAndLanguageAsync(queueDb.Type.Id, _lang, cancellationToken);

                    if (template is null)
                    {
                        return false;
                    }

                    var confirmationEmail = JsonSerializer.Deserialize<ConfirmationEmailEvent>(message);
                    var messageText = string.Format(template.Template, confirmationEmail!.Username, confirmationEmail.Link, _nameSite);
                    var messageSend = new SendMessage(confirmationEmail.Username, confirmationEmail.Email, template.Type.Name, messageText);

                    sender.SendMessage(messageSend, Direction.Email);

                    var messageSave = new CreateMessageModel(template.Type.Id, messageText, Direction.Email);

                    await messageService.AddAsync(messageSave, cancellationToken);

                    return true;

                case "CreateUser":
                    var createUser = JsonSerializer.Deserialize<CreateUserModel>(message);

                    if (createUser is null)
                    {
                        return false;
                    }
                    return await userService.AddAsync(createUser, cancellationToken) != null;

                case "UpdateUser":
                    var updateUser = JsonSerializer.Deserialize<UpdateUserModel>(message);

                    if (updateUser is null)
                    {
                        return false;
                    }
                    return await userService.UpdateAsync(updateUser, cancellationToken);
            }

            return false;
        }
    }
}
