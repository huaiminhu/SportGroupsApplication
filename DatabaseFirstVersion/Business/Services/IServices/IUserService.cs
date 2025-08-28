using SportGroups.Shared.DTOs.UserDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IUserService
    {
        Task<UserInfoDto?> GetUserInfoAsync(int userId);
        Task<bool> UpdateUserAsync(int userId, UserUpdateDto userUpdateDto);
    }
}
