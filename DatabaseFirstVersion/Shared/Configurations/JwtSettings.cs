
namespace SportGroups.Shared.Configurations
{
    public class JwtSettings // JWT設定
    {
        // Token發行者(Server)
        public string Issuer { get; set; } = string.Empty;
        // 受眾(Client)
        public string Audience { get; set; } = string.Empty;
        // 驗證Token的密鑰
        public string SecretKey { get; set; } = string.Empty;
        // 過期時效
        public int ExpireMinutes { get; set; } = 60;
    }
}
