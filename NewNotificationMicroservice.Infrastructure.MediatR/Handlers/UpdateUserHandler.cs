using AutoMapper;
using MediatR;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Application.Services.Abstractions;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Events;
using NewNotificationMicroservice.Infrastructure.MediatR.Commands;
using System.Text.Json;

namespace NewNotificationMicroservice.Infrastructure.MediatR.Handlers
{
    public class UpdateUserHandler(IUserApplicationService userService, IMapper mapper) : IRequestHandler<UpdateUserCommand, bool>
    {
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUser = JsonSerializer.Deserialize<UpdateUserEvent>(request.Message);
            return await userService.UpdateAsync(mapper.Map<UpdateUserModel>(updateUser), cancellationToken);
        }
    }
}
