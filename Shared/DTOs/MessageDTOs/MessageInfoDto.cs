
namespace SportGroups.Shared.DTOs.MessageDTOs
{
    public class MessageInfoDto   // 訊息DTO
    {
        public int MessageId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string MessageContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
    }
}
