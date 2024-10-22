using MediatR;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Commands
{
    public class BidPerLotCommand<TModel> : IRequest<bool> where TModel : class
    {
        public TModel Message { get; }
        public BidPerLotCommand(TModel message) => Message = message;
    }
}
