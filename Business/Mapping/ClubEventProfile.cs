using AutoMapper;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportGroups.Shared.DTOs.ClubEventDTOs;

namespace SportGroups.Business.Mapping
{
    public class ClubEventProfile : Profile
    {
        public ClubEventProfile()
        {
            CreateMap<EventUpdateDto, ClubEvent>()
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<NewEventDto, ClubEvent>();
            CreateMap<ClubEvent, EventInfoDto>();
            //CreateMap<List<ClubEvent>, List<EventInfoDto>>().ReverseMap();
        }
    }
}
