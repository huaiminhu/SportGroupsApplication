using SportGroups.Business.Services.IServices;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> ChangeNickNameAsync(Guid userId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePasswordAsync(Guid userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserInfoAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(UserDto userDto)
        {
            var user = new User 
            { 
                NickName = userDto.NickName, 

            }
        }
    }
}
