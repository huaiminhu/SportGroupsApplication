using AutoMapper;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using SportGroups.Data.Entities;

namespace SportGroups.Business.Mapping
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<NewMemberDto, ClubMember>();
        }
    }
}
