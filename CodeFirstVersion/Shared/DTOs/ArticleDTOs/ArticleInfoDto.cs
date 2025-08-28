using SportGroups.Shared.DTOs.MediaDTOs;
using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class ArticleInfoDto   // 文章資訊DTO
    {
        public int ArticleId { get; set; }
        public Sport Sport { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ArticleContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
        public DateTime EditDate { get; set; }
        public int ClubId { get; set; }
        public List<MediaInfoDto> Medias { get; set; } = new List<MediaInfoDto>();
    }
}
