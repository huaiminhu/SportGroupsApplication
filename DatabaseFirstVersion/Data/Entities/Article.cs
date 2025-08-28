using SportGroups.Shared.Enums;

namespace SportGroups.Data.Entities
{
    public class Article   // 社團文章
    {
        public int ArticleId { get; set; }
        public Sport Sport { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ArticleContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
        public DateTime EditDate { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;
        public ICollection<Media> Medias { get; set; } = new List<Media>();
    }
}
