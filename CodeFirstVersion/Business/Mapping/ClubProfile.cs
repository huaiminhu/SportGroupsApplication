using AutoMapper;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ClubDTOs;

namespace SportGroups.Business.Mapping
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            // 對非null值進行更新
            CreateMap<ClubUpdateDto, Club>()
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<NewClubDto, Club>();
            CreateMap<Club, ClubInfoDto>();
        }
    }
}
