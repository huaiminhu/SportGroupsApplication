
namespace SportGroups.Shared.DTOs.MessageDTOs
{
    public class NewMessageDto   // 訊息新增DTO
    {
        public string Title { get; set; } = string.Empty;
        public string MessageContent { get; set; } = string.Empty;
        public int ClubId { get; set; }
    }
}
