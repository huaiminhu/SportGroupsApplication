using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs
{
    public class RegisterDto
    {
        public string NickName { get; set; } = "";
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; } = 0;
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }
}
