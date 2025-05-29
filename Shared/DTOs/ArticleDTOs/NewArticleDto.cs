using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class NewArticleDto
    {
        public string Title { get; set; } = string.Empty;
        public string ArticleContent { get; set; } = string.Empty;
        public int ClubId { get; set; }
        public List<IFormFile> Medias { get; set; } = new List<IFormFile>();
        public List<string> YouTubeUrls { get; set; } = new List<string>(); // 輸入 YouTube 連結
    }
}
