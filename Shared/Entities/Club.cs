using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.Entities
{
    public class Club   // 社團
    {
        public int ClubId { get; set; }
        public string ClubName { get; set; } = string.Empty;
        public Sport Sport { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime establishedDate { get; set; }
        public ICollection<ClubMember> Members { get; set; } = new List<ClubMember>();
        public ICollection<ClubEvent> Events { get; set; } = new List<ClubEvent>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
