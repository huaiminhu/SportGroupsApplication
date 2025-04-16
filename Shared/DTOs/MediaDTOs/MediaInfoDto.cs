﻿using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.MediaDTOs
{
    public class MediaInfoDto
    {
        public int ArticleMediaId { get; set; }
        public MediaType MediaType { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; }
    }
}
