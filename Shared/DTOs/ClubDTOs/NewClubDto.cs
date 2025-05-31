using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Shared.DTOs.MessageDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.ClubDTOs
{
    public class NewClubDto
    {
        public string ClubName { get; set; } = string.Empty;
        public Sport Sport { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<NewMemberDto> Members { get; set; } = new List<NewMemberDto>();
        //public List<NewEventDto> Events { get; set; } = new List<NewEventDto>();
        //public List<NewMessageDto> Messages { get; set; } = new List<NewMessageDto>();
        //public List<NewArticleDto> Articles { get; set; } = new List<NewArticleDto>();
    }
}
