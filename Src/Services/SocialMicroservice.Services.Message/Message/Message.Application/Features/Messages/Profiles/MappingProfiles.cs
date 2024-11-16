using AutoMapper;
using Message.Application.Features.Messages.Dtos;
using Message.Application.Features.Messages.Models;
using Message.Domain;

namespace Message.Application.Features.Messages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {

        CreateMap<Messagess, DeleteMessageCommand>().ReverseMap();
        CreateMap<Messagess, DeletedMessageDto>().ReverseMap();
        CreateMap<Messagess, MessageDto>().ReverseMap();
        CreateMap<Messagess, MessageListDto>().ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Users.Name));
        CreateMap<Messagess, MessageListModel>();
    }
}