using Microsoft.AspNetCore.Http;
using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class NewArticleDto   // 文章新增DTO
    {
        public Sport Sport { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ArticleContent { get; set; } = string.Empty;
        public int ClubId { get; set; }
        public List<IFormFile> Medias { get; set; } = new List<IFormFile>();
        
        // YouTube類型媒體網址
        public List<string> YouTubeUrls { get; set; } = new List<string>(); // 輸入 YouTube 連結
    }
}
