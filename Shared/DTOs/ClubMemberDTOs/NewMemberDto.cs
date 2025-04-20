using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ClubMemberDTOs
{
    public class NewMemberDto
    {
        public int UserId { get; set; }
        public int ClubId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
