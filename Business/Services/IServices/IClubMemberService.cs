using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubMemberService
    {
        // 加入社團
        Task<bool> JoinClubAsync(NewMemberDto newMemberDto);
        // 取得使用者加入的所有社團
        Task<List<ClubInfoDto>> GetAllClubsOfUserAsync(int userId);
    }
}
