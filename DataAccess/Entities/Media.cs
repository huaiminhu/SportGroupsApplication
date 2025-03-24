using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Media   // 文章媒體
    {
        public int ArticleMediaId { get; set; }
        public required string Url { get; set; }
        public required DateTime AddedDate { get; set; } = DateTime.Now;
        public int ArticleId { get; set; }
        public required Article Article { get; set; }
    }
}
