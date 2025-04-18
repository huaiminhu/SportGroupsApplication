using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.Entities
{
    public class Enrollment   // 活動報名
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int ClubEventId { get; set; }
        public ClubEvent Event { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public DateTime EnrollDate { get; set; }
    }
}
