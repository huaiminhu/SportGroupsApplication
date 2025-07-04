using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using SportGroups.Shared.DTOs.ResultDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubMemberService
    {
        // 加入社團
        Task<ResultDto<MemberInfoDto>> JoinClubAsync(NewMemberDto newMemberDto);
        // 取得使用者加入的所有社團
        Task<List<ClubInfoDto>> GetAllClubsOfUserAsync(int userId);
        // 取得社團成員
        Task<ResultDto<MemberInfoDto>> GetMemberAsync(int userId, int clubId);
    }
}
