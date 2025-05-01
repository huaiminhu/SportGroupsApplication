using AutoMapper;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<NewMemberDto, ClubMember>().ReverseMap();
        }
    }
}
