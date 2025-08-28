using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.ResultDTOs;
using SportGroups.Shared.DTOs.UserDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IAuthService
    {
        // 註冊
        Task<ResultDto> RegisterAsync(RegisterDto registerDto);
        // 驗證使用者
        Task<UserInfoDto?> AuthAsync(LoginDto loginDto);
        // 定時更新Token讓使用者不必不時重新登入驗證
        Task<UserInfoDto?> RefreshTokenAsync(string refreshToken);
    }
}
