using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class WonLotCommand<TModel> : IRequest<bool> where TModel : class
    {
        public TModel Message { get; }
        public WonLotCommand(TModel message) => Message = message;
    }
}
