using SportGroups.Shared.Enums;

namespace SportGroups.Shared.DTOs.ClubDTOs
{
    public class NewClubDto   // 社團新增DTO
    {
        public string ClubName { get; set; } = string.Empty;
        public Sport Sport { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
