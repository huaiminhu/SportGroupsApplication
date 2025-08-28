using SportGroups.Data.Entities;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IClubMemberRepository
    {
        // 新增社團成員
        Task<int> AddMemberAsync(int userId, int clubId, DateTime joinDate);
        // 取得使用者參與的所有社團
        Task<List<Club>> GetAllClubsOfUserAsync(int userId);
        // 取得社團成員
        Task<ClubMember?> GetMemberAsync(int userId, int clubId);
        // 刪除社團成員
        Task<int> DeleteMemberAsync(int userId, int clubId);
    }
}
