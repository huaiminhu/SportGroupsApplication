using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ClubDTOs
{
    public class CreateClubDto
    {
        public string ClubName { get; set; } = string.Empty;
        public Sport Sport { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime establishedDate { get; set; }
    }
}
