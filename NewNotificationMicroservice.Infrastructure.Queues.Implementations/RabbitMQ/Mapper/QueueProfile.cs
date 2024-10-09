using AutoMapper;
using NewNotificationMicroservice.Application.Models.BusQueue;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Common.Infrastructure.Queues.Events;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Models;

namespace NewNotificationMicroservice.Infrastructure.Queues.Implementations.RabbitMQ.Mapper
{
    public class QueueProfile : Profile
    {
        public QueueProfile()
        {
            CreateMap<BusQueue, BusQueueModel>()
                    .ForMember(d => d.QueueName, o => o.MapFrom(s => s.QueueName.Value))
                    .ReverseMap();
            CreateMap<CreateUserEvent, CreateUserModel>().ReverseMap();
            CreateMap<UpdateUserEvent, UpdateUserModel>().ReverseMap();
        }
    }
}
