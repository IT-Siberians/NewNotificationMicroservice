using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class UpdateUserCommand<TModel> : IRequest<bool> where TModel : class
    {
        public TModel Message { get; }
        public UpdateUserCommand(TModel message) => Message = message;
    }
}
