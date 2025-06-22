
namespace SportGroups.Shared.DTOs.ClubMemberDTOs
{
    public class NewMemberDto   // 社團成員新增DTO
    {
        public int UserId { get; set; }
        public int ClubId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
