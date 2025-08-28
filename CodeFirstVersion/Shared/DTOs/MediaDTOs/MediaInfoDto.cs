using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.MediaDTOs
{
    public class MediaInfoDto   // 媒體資訊DTO
    {
        public int MediaId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; }
    }
}
