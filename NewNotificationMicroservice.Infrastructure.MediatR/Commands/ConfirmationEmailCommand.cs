using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class ConfirmationEmailCommand : IRequest<bool>
    {
        public string Message { get; }
        public ConfirmationEmailCommand(string message) => Message = message;
    }
}
