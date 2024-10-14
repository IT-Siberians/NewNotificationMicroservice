using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class CreateUserCommand<TModel> : IRequest<bool>
    {
        public TModel Message { get; }
        public CreateUserCommand(TModel message) => Message = message;
    }
}
