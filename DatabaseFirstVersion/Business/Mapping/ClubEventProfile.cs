using AutoMapper;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ClubEventDTOs;

namespace SportGroups.Business.Mapping
{
    public class ClubEventProfile : Profile
    {
        public ClubEventProfile()
        {
            // 對非null值進行更新
            CreateMap<EventUpdateDto, ClubEvent>()
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<NewEventDto, ClubEvent>();
            CreateMap<ClubEvent, EventInfoDto>();
        }
    }
}
