using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Message { get; }
        public CreateUserCommand(string message) => Message = message;
    }
}
