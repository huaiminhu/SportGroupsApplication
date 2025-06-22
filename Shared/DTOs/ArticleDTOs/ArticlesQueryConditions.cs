using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class ArticlesQueryConditions   // 文章查詢條件DTO
    {
        public int? ClubId { get; set; }
        public Sport? Sport { get; set; }
        public string? Keyword { get; set; }
    }
}
