using AutoMapper;
using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.UserDTOs;
using SportGroups.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserInfoDto>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
        }
    }
}
