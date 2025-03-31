using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserDto user);
        Task<LogInResponse?> ValidateUserAsync(string username, string password);
        Task<bool> ChangeNickNameAsync(Guid userId, string newName);
        Task<bool> ChangePasswordAsync(Guid userId, string newPassword);
    }
}
