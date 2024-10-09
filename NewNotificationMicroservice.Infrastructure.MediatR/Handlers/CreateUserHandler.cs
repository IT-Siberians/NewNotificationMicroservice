using AutoMapper;
using MediatR;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Events;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using System.Text.Json;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class CreateUserHandler(IUserApplicationService userService, IMapper mapper) : IRequestHandler<CreateUserCommand, bool>
    {
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUser = JsonSerializer.Deserialize<CreateUserEvent>(request.Message);
            return await userService.AddAsync(mapper.Map<CreateUserModel>(createUser), cancellationToken) != null;
        }
    }
}
