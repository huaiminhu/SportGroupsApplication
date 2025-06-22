using AutoMapper;
using SportGroups.Shared.DTOs.UserDTOs;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.AuthDTOs;

namespace SportGroups.Business.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // 對非null值進行更新
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<User, UserInfoDto>();
            CreateMap<RegisterDto, User>();
        }
    }
}
