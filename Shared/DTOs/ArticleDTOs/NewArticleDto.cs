using SportGroups.Shared.DTOs.MediaDTOs;
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
        public List<NewMediaDto> Medias { get; set; } = new List<NewMediaDto>();
    }
}
