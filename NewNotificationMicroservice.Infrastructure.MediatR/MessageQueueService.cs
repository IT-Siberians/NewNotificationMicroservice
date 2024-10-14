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
                "ConfirmationEmail" => await mediator.Send(new ConfirmationEmailCommand<string>(message), cancellationToken),
                "CreateUser" => await mediator.Send(new CreateUserCommand<string>(message), cancellationToken),
                "UpdateUser" => await mediator.Send(new UpdateUserCommand<string>(message), cancellationToken),
                _ => false
            };
        }
    }
}
