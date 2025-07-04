using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.EventDTOs
{
    public class EventInfoDto   // 活動資訊DTO
    {
        public int ClubEventId { get; set; }
        public Sport Sport { get; set; }
        public EventType EventType { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
        public int ClubId { get; set; }
    }
}
