using SportGroups.Shared.DTOs.MediaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class ArticleInfoDto
    {
        public int ArticleId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ArticleContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
        public DateTime EditDate { get; set; }
        public List<MediaInfoDto> Medias { get; set; } = new List<MediaInfoDto>();
    }
}
