using SportGroups.Shared.DTOs.AuthDTOs;
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
        // 註冊
        Task<bool> RegisterAsync(RegisterDto registerDto);

        // 使用使用者名稱取得使用者資訊
        Task<UserInfoDto> GetUserByUsernameAsync(string username);
        Task<UserInfoDto> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserAsync(UserUpdateDto userUpdateDto);
        //Task<bool> ChangeNickNameAsync(int userId, string newName);
        //Task<bool> ChangePasswordAsync(int userId, string newPassword);
    }
}
