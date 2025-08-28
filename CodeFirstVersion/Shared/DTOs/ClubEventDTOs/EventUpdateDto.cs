
namespace SportGroups.Shared.DTOs.ClubEventDTOs
{
    public class EventUpdateDto   // 活動更新DTO
    {
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public DateTime? Starting { get; set; }
        public DateTime? Ending { get; set; }
    }
}
