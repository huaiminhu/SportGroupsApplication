
namespace SportGroups.Data.Entities
{
    public class ClubMember   // 社團成員
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;
        public DateTime JoinTime { get; set; }
    }
}
