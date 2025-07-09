using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;

namespace SportGroups.Data.Repositories
{
    public class ClubMemberRepository : IClubMemberRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubMemberRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddMemberAsync(int userId, int clubId, DateTime joinDate)
        {
            // 呼叫stored procedure
            return await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Create_ClubMembers_AddMember {userId}, {clubId}, {joinDate}");
        }

        public async Task<List<Club>> GetAllClubsOfUserAsync(int userId)
        {
            var uIdParam = new SqlParameter("@userId", userId);

            // 呼叫stored procedure
            return await _context.Clubs
                .FromSqlRaw("EXEC usp_GetAll_ClubMembers_ClubsOfUser @userId", uIdParam)
                .ToListAsync();
        }

        public async Task<ClubMember?> GetMemberAsync(int userId, int clubId)
        {
            return await _context.ClubMembers
                .FirstOrDefaultAsync(m => m.UserId == userId && m.ClubId == clubId);
        }

        public async Task<int> DeleteMemberAsync(int userId, int clubId)
        {
            // 呼叫stored procedure
            return await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Delete_ClubMembers_DeleteMember {userId}, {clubId}");
        }
    }
}
