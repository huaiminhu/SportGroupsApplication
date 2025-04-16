﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportGroups.Shared.Enums;

namespace SportGroups.Data.Entities
{
    public class Media   // 文章媒體
    {
        public int ArticleMediaId { get; set; }
        public MediaType MediaType { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; } = null!;
    }
}
