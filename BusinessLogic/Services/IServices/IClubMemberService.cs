using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubMemberService
    {
        Task<bool> JoinClubAsync(NewMemberDto newMemberDto);
        Task<List<ClubInfoDto>> GetAllClubsOfUserAsync(Guid userId);
    }
}
