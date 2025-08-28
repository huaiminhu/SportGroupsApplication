using SportGroups.Shared.Enums;

namespace SportGroups.Data.Entities
{
    public class Media   // 文章媒體
    {
        public int MediaId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; } = null!;
    }
}
