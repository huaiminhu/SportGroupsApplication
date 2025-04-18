using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.Entities
{
    public class Article   // 社團文章
    {
        public int ArticleId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ArticleContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
        public DateTime EditDate { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;
        public ICollection<Media> Medias { get; set; } = new List<Media>();
    }
}
