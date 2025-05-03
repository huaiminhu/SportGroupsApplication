using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ClubEventDTOs
{
    public class EventUpdateDto
    {
        public int ClubEventId { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public DateTime? Starting { get; set; }
        public DateTime? Ending { get; set; }
    }
}
