using Microsoft.AspNetCore.Http;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class ArticleUpdateDto   // 文章更新DTO
    {
        public string? Title { get; set; }
        public string? ArticleContent { get; set; }
        public DateTime? EditDate { get; set; }
        public List<IFormFile>? Medias { get; set; }

        // 需保留的媒體ID
        public List<int>? StayMediaIds { get; set; } = null!;// 要保留的 media id
        public List<string>? YouTubeUrls { get; set; }
    }
}
