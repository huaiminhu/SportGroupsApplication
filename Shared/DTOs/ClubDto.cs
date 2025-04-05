using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs
{
    public class ClubDto
    {
        public int ClubId { get; set; }
        [Required]
        public string ClubName { get; set; }
        [Required]
        public Sport Sport { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime establishedDate { get; set; }
    }
}
