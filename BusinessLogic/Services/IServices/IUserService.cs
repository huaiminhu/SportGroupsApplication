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
        // 取得使用者資訊
        Task<UserInfoDto> GetUserInfoAsync(int userId);
        Task<bool> ChangeNickNameAsync(int userId, string newName);
        Task<bool> ChangePasswordAsync(int userId, string newPassword);
    }
}
