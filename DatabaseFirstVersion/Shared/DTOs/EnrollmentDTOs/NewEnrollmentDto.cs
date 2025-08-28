
namespace SportGroups.Shared.DTOs.EnrollmentDTOs
{
    public class NewEnrollmentDto   // 報名新增DTO
    {
        public int ClubEventId { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}
