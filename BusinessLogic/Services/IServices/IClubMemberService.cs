using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubMemberService
    {
        Task<bool> JoinClubAsync(ClubMemberDto clubMemberDto);
        Task<List<ClubDto>> GetAllClubsOfUserAsync(Guid userId);
    }
}
