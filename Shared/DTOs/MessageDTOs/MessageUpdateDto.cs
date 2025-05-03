using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.MessageDTOs
{
    public class MessageUpdateDto
    {
        public int MessageId { get; set; }
        public string? Title { get; set; }
        public string? MessageContent { get; set; }
    }
}
