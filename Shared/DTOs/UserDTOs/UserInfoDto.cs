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
        public int UserId { get; set; }
        [Required]
        public string NickName { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
    }
}
