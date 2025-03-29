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

        public Task<bool> ChangeNickNameAsync(Guid userId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePasswordAsync(Guid userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> ValidateUserAsync(string username, string password)
        {
            var existing = await _userRepository.GetUserAsync(username);
            if(existing == null || !BCrypt.Net.BCrypt.Verify(password, existing.PasswordHash))
            {
                return null;
            }
            return new UserDto { 

            };
        }

        public Task<bool> RegisterAsync(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
