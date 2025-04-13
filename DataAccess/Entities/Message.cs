using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Entities
{
    public class Message   // 社團訊息
    {
        public int MessageId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string MessageContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;
    }
}
