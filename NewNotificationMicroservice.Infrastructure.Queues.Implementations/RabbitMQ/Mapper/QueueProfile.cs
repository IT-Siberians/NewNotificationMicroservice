using AutoMapper;
using NewNotificationMicroservice.Application.Models.BusQueue;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Infrastructure.RabbitMQ.Models;
using Otus.QueueDto.User;

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
