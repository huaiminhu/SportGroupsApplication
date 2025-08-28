
namespace SportGroups.Shared.DTOs.EnrollmentDTOs
{
    public class EnrollmentInfoDto   // 報名資訊DTO
    {
        public int UserId { get; set; }
        public int ClubEventId { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime EnrollDate { get; set; }
    }
}
