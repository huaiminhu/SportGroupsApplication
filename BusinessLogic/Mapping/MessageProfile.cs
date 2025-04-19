using AutoMapper;
using SportGroups.Shared.DTOs.MessageDTOs;
using SportGroups.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<NewMessageDto, Message>().ReverseMap();
            CreateMap<Message, MessageInfoDto>().ReverseMap();
            CreateMap<List<Message>, List<MessageInfoDto>>().ReverseMap();
        }
    }
}
