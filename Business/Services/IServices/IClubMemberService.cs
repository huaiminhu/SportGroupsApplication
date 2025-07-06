using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ResultDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubMemberService
    {
        // 加入社團
        Task<ResultDto> JoinClubAsync(int userId, int clubId);
        // 取得使用者加入的所有社團
        Task<List<ClubInfoDto>> GetAllClubsOfUserAsync(int userId);
        // 取得社團成員
        Task<ResultDto> GetMemberAsync(int userId, int clubId);
        // 刪除社團成員
        Task<bool> DeleteMemberAsync(int userId, int clubId);
    }
}
