using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class ConfirmationEmailCommand<TModel> : IRequest<bool> where TModel : class
    {
        public TModel Message { get; }
        public ConfirmationEmailCommand(TModel message) => Message = message;
    }
}
