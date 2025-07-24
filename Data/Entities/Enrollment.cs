
namespace SportGroups.Data.Entities
{
    public class Enrollment   // 活動報名
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int ClubEventId { get; set; }
        public ClubEvent ClubEvent { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public DateTime EnrollDate { get; set; }
    }
}
