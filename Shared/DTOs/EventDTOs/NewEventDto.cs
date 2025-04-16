using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.EventDTOs
{
    public class NewEventDto
    {
        public EventType EventType { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
    }
}
