using MediatR;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;

namespace NewNotificationMicroservice.Infrastructure.MediatR
{
    public class MessageQueueService(IMediator mediator)
    {
        public async Task<bool> WorckAsync(string message, string queue, CancellationToken cancellationToken)
        {
            return queue switch
            {
                "ConfirmationEmail" => await mediator.Send(new ConfirmationEmailCommand(message), cancellationToken),
                "CreateUser" => await mediator.Send(new CreateUserCommand(message), cancellationToken),
                "UpdateUser" => await mediator.Send(new UpdateUserCommand(message), cancellationToken),
                _ => false
            };
        }
    }
}
