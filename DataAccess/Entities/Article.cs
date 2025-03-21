﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Article   // 社團文章
    {
        public int BlogId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required DateTime PostDate { get; set; }
        public required DateTime EditDate { get; set; }
        public int ClubId { get; set; }
        public required Club Club { get; set; }
        public required ICollection<Media> Medias { get; set; } = new List<Media>();
    }
}
