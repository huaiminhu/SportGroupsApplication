using Microsoft.AspNetCore.Http;
using SportGroups.Shared.DTOs.MediaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class ArticleUpdateDto
    {
        public int ArticleId { get; set; }
        public string? Title { get; set; }
        public string? ArticleContent { get; set; }
        public DateTime? EditDate { get; set; }
        public List<IFormFile>? Medias { get; set; }
        public List<int>? StayMediaIds { get; set; } = null!;// 要保留的 media id
    }
}
