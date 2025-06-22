using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.EventDTOs
{
    public class NewEventDto   // 活動新增DTO
    {
        public EventType EventType { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
        public int ClubId { get; set; }
    }
}
