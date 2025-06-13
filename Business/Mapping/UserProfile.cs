using AutoMapper;
using SportGroups.Shared.DTOs.UserDTOs;
using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportGroups.Shared.DTOs.AuthDTOs;

namespace SportGroups.Business.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<User, UserInfoDto>();
                //.ForMember(destination => destination.Clubs,
                //       option => option.MapFrom(source => source.Clubs.Select(cmember => cmember.Club)));
            CreateMap<RegisterDto, User>().ReverseMap();
        }
    }
}
