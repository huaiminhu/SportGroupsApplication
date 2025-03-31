using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        [Required]
        public string? NickName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public required Role Role { get; set; }
        [Required]
        public required DateTime RegisterDate { get; set; }
    }
}
