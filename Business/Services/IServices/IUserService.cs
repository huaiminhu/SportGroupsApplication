using SportGroups.Shared.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IUserService
    {
        Task<UserInfoDto> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserAsync(int userId, UserUpdateDto userUpdateDto);
        //Task<bool> ChangeNickNameAsync(int userId, string newName);
        //Task<bool> ChangePasswordAsync(int userId, string newPassword);
    }
}
