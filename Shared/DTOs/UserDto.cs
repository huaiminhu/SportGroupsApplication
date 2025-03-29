using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string? NickName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required Role Role { get; set; }
        public required DateTime RegisterDate { get; set; }
        public required IEnumerable<ClubMemberDto> Clubs { get; set; }
        public required IEnumerable<EnrollmentDto> Enrollments { get; set; }
    }
}
