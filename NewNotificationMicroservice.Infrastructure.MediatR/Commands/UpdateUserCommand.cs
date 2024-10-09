using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public string Message { get; }
        public UpdateUserCommand(string message) => Message = message;
    }
}
