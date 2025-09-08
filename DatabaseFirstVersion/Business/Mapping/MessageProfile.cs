using AutoMapper;
using SportGroups.Shared.DTOs.MessageDTOs;
using SportGroups.Data.Entities;

namespace SportGroups.Business.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            // 對非null值進行更新
            CreateMap<MessageUpdateDto, ClubMessage>()
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<NewMessageDto, ClubMessage>();
            CreateMap<ClubMessage, MessageInfoDto>();
        }
    }
}
