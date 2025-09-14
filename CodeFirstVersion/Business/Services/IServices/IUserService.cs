using SportGroups.Shared.DTOs.UserDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IUserService
    {
        Task<UserInfoDto?> GetUserInfoAsync(int userId);

        // 更改使用者密碼
        Task<bool> ChangePasswordAsync(int userId, string password);

        // 更改使用者暱稱
        Task<bool> ChangeNickNameAsync(int userId, string nickname);
    }
}
