using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Entities
{
    public class User   // 使用者
    {
        public Guid UserId { get; set; }
        public required string NickName { get; set; } = "";
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required Role Role { get; set; } = 0;
        public required DateTime RegisterDate { get; set; } = DateTime.Now;
        public required ICollection<ClubMember> Clubs { get; set; } = new List<ClubMember>();
        public required ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
