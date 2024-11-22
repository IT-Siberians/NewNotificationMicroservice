using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class CancelLotCommand<TModel> : IRequest<bool> where TModel : class
    {
        public TModel Message { get; }
        public CancelLotCommand(TModel message) => Message = message;
    }
}
