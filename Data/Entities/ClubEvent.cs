using SportGroups.Shared.Enums;

namespace SportGroups.Data.Entities
{
    public class ClubEvent   // 社團活動
    {
        public int ClubEventId { get; set; }
        public EventType EventType { get; set; }
        public Sport Sport { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
