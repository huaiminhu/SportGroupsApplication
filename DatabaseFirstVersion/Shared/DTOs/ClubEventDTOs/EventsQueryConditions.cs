using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.ClubEventDTOs
{
    public class EventsQueryConditions   // 活動查詢條件DTO
    {
        public int? ClubId { get; set; }
        public Sport? Sport { get; set; }
        public string? Keyword { get; set; }
    }
}
