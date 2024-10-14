using AutoMapper;
using MediatR;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class UpdateUserHandler(IUserApplicationService userService, IMapper mapper) : IRequestHandler<UpdateUserCommand<UpdateUserEvent>, bool>
    {
        public async Task<bool> Handle(UpdateUserCommand<UpdateUserEvent> request, CancellationToken cancellationToken)
        {
            return await userService.UpdateAsync(mapper.Map<UpdateUserModel>(request.Message), cancellationToken);
        }
    }
}
