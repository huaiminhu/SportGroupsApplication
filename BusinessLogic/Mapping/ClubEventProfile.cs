using AutoMapper;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class ClubEventProfile : Profile
    {
        public ClubEventProfile()
        {
            CreateMap<NewEventDto, ClubEvent>().ReverseMap();
            CreateMap<ClubEvent, EventInfoDto>().ReverseMap();
            CreateMap<List<ClubEvent>, List<EventInfoDto>>().ReverseMap();
        }
    }
}
