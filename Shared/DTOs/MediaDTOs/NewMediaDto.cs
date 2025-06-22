using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.MediaDTOs
{
    public class NewMediaDto   // 媒體新增DTO
    {
        public string FileName { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public int ArticleId { get; set; }
    }
}
