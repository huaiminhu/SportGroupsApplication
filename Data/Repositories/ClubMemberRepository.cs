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

        public async Task AddMemberAsync(int userId, int clubId, DateTime joinDate)
        {
            //var uIdParam = new SqlParameter("@userId", userId);
            //var cIdParam = new SqlParameter("@clubId", clubId);
            //var dateParam = new SqlParameter("@joinDate", joinDate);

            //// 呼叫stored procedure
            //await _context.Database
            //    .ExecuteSqlRawAsync(
            //    "EXEC usp_Create_ClubMembers_AddMember @userId, @clubId, @joinDate",
            //    uIdParam, cIdParam, dateParam);
            await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Create_ClubMembers_AddMember {userId}, {clubId}, {joinDate}");
        }

        public async Task<List<Club>> GetAllClubsOfUserAsync(int userId)
        {
            var uIdParam = new SqlParameter("@userId", userId);

            // 呼叫stored procedure
            return await _context.Clubs
                .FromSqlRaw("EXEC usp_GetAll_Clubs_OfUser @userId", uIdParam)
                .ToListAsync();
        }

        public async Task<ClubMember?> GetMemberAsync(int userId, int clubId)
        {
            return await _context.ClubMembers
                .FirstOrDefaultAsync(m => m.UserId == userId && m.ClubId == clubId);
        }

        public async Task DeleteMemberAsync(int userId, int clubId)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Delete_ClubMembers_DeleteMember {userId}, {clubId}");
        }
    }
}
