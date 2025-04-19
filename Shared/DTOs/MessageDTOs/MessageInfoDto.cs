using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.MessageDTOs
{
    public class MessageInfoDto
    {
        public string Title { get; set; } = string.Empty;
        public string MessageContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
    }
}
