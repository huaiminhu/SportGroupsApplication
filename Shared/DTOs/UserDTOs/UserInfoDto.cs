using SportGroups.Shared.Entities;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.UserDTOs
{
    public class UserInfoDto
    {
        public string NickName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public ICollection<ClubMember> Clubs { get; set; } = new List<ClubMember>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
