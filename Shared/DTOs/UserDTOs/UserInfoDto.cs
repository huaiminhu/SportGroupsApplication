using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.EnrollmentDTOs;
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
        public Role Role { get; set; }
        //public List<ClubInfoDto> Clubs { get; set; } = new List<ClubInfoDto>();
        //public List<EnrollmentInfoDto> Enrollments { get; set; } = new List<EnrollmentInfoDto>();
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
