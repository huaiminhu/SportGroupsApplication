using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Entities
{
    public class ClubMember   // 社團成員
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public DateTime JoinTime { get; set; }
    }
}
