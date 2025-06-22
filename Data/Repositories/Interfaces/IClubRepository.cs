using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ClubDTOs;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IClubRepository
    {
        Task CreateClubAsync(Club club);
        Task<Club?> GetClubByIdAsync(int clubId);

        // 依條件取得指定社團
        Task<List<Club>> GetClubsByConditionAsync(ClubsQueryConditions condition);
        void UpdateClub(Club club);
        void DeleteClub(Club club);
    }
}
