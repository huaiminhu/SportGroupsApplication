
namespace SportGroups.Shared.DTOs.EnrollmentDTOs
{
    public class NewEnrollmentDto   // 報名新增DTO
    {
        public int UserId { get; set; }
        public int ClubEventId { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}
