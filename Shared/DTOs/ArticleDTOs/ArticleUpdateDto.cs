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
    }
}
