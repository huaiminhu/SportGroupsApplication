using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ArticleDTOs
{
    public class ArticlesQueryConditions
    {
        public int? ClubId { get; set; }
        public Sport? Sport { get; set; }
        public string? Keyword { get; set; }
    }
}
