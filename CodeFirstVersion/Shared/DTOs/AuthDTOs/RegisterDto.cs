using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.AuthDTOs
{
    public class RegisterDto   // 註冊資訊DTO
    {
        public string NickName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}
