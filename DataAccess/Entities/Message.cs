using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Message   // 社團訊息
    {
        public int MessageId { get; set; }
        public required string Title { get; set; }
        public required string MessageContent { get; set; }
        public required DateTime PostDate { get; set; }
        public int ClubId { get; set; }
        public required Club Club { get; set; }
    }
}
