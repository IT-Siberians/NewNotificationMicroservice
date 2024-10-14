using AutoMapper;
using MediatR;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using Otus.QueueDto;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class CreateUserHandler(IUserApplicationService userService, IMapper mapper) : IRequestHandler<CreateUserCommand<CreateUserEvent>, bool>
    {
        public async Task<bool> Handle(CreateUserCommand<CreateUserEvent> request, CancellationToken cancellationToken)
        {
            return await userService.AddAsync(mapper.Map<CreateUserModel>(request.Message), cancellationToken) != null;
        }
    }
}
