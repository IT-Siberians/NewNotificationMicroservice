using AutoMapper;
using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Models.Template;
using NewNotificationMicroservice.Application.Models.Type;
using NewNotificationMicroservice.Application.Models.User;
using NewNotificationMicroservice.Domain.Entities;

namespace NewNotificationMicroservice.Application.Services.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<MessageType, TypeModel>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Value))
                .ReverseMap();
            CreateMap<MessageTemplate, TemplateModel>().ReverseMap();
            CreateMap<Message, MessageModel>().ReverseMap();
            CreateMap<User, UserModel>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Username.Value))
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.FullName.Value))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Value))
                .ReverseMap();
        }
    }
}
