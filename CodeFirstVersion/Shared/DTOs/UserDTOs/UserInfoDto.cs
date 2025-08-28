using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.UserDTOs
{
    public class UserInfoDto   // 使用者資訊DTO
    {
        public string NickName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public Role Role { get; set; }
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
