using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Activity   // 社團活動
    {
        public int ActivityId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; } = "";
        public required string Address { get; set; }
        public required DateTime Starting { get; set; }
        public required DateTime Ending { get; set; }
        public int ClubId { get; set; }
        public required Club Club { get; set; }
        public required ICollection<User> Members { get; set; } = new List<User>();
    }
}
