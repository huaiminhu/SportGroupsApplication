using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Enrollment   // 活動報名
    {
        public int UserId { get; set; }
        public required User User { get; set; }
        public int ClubEventId { get; set; }
        public required ClubEvent Event { get; set; }
        public required string Phone { get; set; }
        public required DateTime EnrollDate { get; set; } = DateTime.Now;
    }
}
