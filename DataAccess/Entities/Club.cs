using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Entities
{
    public class Club   // 社團
    {
        public int ClubId { get; set; }
        public required string ClubName { get; set; }
        public required Sport Sport { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Description { get; set; } = "";
        public required DateTime establishedDate { get; set; } = DateTime.Now;
        public required ICollection<ClubMember> Members { get; set; } = new List<ClubMember>();
        public required ICollection<ClubEvent> Events { get; set; } = new List<ClubEvent>();
        public required ICollection<Message> Messages { get; set; } = new List<Message>();
        public required ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
