using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.Entities
{
    public class User   // 使用者
    {
        public int UserId { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Role Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<ClubMember> Clubs { get; set; } = new List<ClubMember>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
