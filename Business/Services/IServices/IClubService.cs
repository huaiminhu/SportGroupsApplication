using SportGroups.Shared.DTOs.ClubDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubService
    {
        // 依指定條件取得社團
        Task<List<ClubInfoDto>> GetClubsByConditionAsync(ClubsQueryConditions condition);
        Task<ClubInfoDto?> GetClubByIdAsync(int clubId);
        Task<int?> CreateClubAsync(int userId, NewClubDto newClubDto);
        Task<bool> UpdateClubAsync(int clubId, ClubUpdateDto newClubUpdateDto);
        Task<bool> DeleteClubAsync(int clubId);
    }
}
