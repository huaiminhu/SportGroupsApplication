using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.ClubDTOs
{
    public class ClubsQueryConditions   // 社團查詢條件DTO
    {
        public Sport? Sport { get; set; }
        public string? Keyword { get; set; }
    }
}
