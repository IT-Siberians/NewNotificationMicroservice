using AutoMapper;
using NewNotificationMicroservice.Application.Models.BusQueue;
using NewNotificationMicroservice.Application.Models.Message;
using NewNotificationMicroservice.Application.Models.Template;
using NewNotificationMicroservice.Application.Models.Type;
using NewNotificationMicroservice.Web.Contracts.BusQueue;
using NewNotificationMicroservice.Web.Contracts.Message;
using NewNotificationMicroservice.Web.Contracts.Template;
using NewNotificationMicroservice.Web.Contracts.Type;

namespace NewNotificationMicroservice.Web.Mapper
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<TypeModel, TypeResponse>();
            CreateMap<AddTypeRequest, CreateTypeModel>();
            CreateMap<EditTypeRequest, UpdateTypeModel>();
            CreateMap<DeleteTypeRequest, DeleteTypeModel>();

            CreateMap<MessageModel, MessageResponse>();

            CreateMap<TemplateModel, TemplateResponse>();
            CreateMap<AddTemplateRequest, CreateTemplateModel>();
            CreateMap<EditTemplateRequest, UpdateTemplateModel>();
            CreateMap<DeleteTemplateRequest, DeleteTemplateModel>();

            CreateMap<BusQueueModel, BusQueueResponse>();
            CreateMap<AddBusQueueRequest, CreateBusQueueModel>();
            CreateMap<EditBusQueueRequest, UpdateBusQueueModel>();
            CreateMap<DeleteBusQueueRequest, DeleteBusQueueModel>();
        }
    }
}
