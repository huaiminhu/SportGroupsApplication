using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Entities
{
    public class Article   // 社團文章
    {
        public int ArticleId { get; set; }
        public required string Title { get; set; }
        public required string ArticleContent { get; set; }
        public required DateTime PostDate { get; set; } = DateTime.Now;
        public required DateTime EditDate { get; set; } = DateTime.Now;
        public int ClubId { get; set; }
        public required Club Club { get; set; }
        public required ICollection<Media> Medias { get; set; } = new List<Media>();
    }
}
