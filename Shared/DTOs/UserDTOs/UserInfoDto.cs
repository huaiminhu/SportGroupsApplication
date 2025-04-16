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
        public string NickName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
