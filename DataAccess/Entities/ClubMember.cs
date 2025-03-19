using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ClubMember   // 社團成員
    {
        public int UserId { get; set; }
        public required User User { get; set; }
        public int ClubId { get; set; }
        public required Club Club { get; set; }
        public required string Email { get; set; }
        public required DateTime JoinTime { get; set; } = DateTime.Now;
    }
}
