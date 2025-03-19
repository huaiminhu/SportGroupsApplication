using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User   // 使用者
    {
        public Guid UserId { get; set; }
        public required string NickName { get; set; } = "";
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required Role Role { get; set; } = 0;
        public required ICollection<Club> Clubs { get; set; } = new List<Club>();
        public required ICollection<ClubActivity> Activities { get; set; } = new List<ClubActivity>();
    }
}
