using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs
{
    public class ArticleDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string ArticleContent { get; set; } = string.Empty;
        [Required]
        public DateTime PostDate { get; set; }
        [Required]
        public DateTime EditDate { get; set; }
        [Required]
        public int ClubId { get; set; }
        [Required]
        public ClubDto Club { get; set; } = new ClubDto();
        public ICollection<MediaDto>? Medias { get; set; }
    }
}
