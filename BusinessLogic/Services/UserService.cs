using SportGroups.Business.Services.IServices;
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

        public async Task<bool> ChangeNickNameAsync(Guid userId, string newName)
        {
            return await _userRepository.UpdateNickNameAsync(userId, newName);
        }

        public async Task<bool> ChangePasswordAsync(Guid userId, string newPassword)
        {
            return await _userRepository.UpdatePasswordAsync(userId, newPassword);
        }

        public Task<UserDto> GetUserInfoAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
