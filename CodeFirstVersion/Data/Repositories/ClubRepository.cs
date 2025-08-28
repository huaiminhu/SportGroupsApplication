using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using SportGroups.Shared.DTOs.ClubDTOs;

namespace SportGroups.Data.Repositories
{
    public class ClubRepository : IClubRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task CreateClubAsync(Club club)
        {
            await _context.Clubs.AddAsync(club);
        }

        public async Task<Club?> GetClubByIdAsync(int clubId)
        {
            return await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
        }

        public void DeleteClub(Club club)
        {
            _context.Clubs.Remove(club);
        }

        public async Task<List<Club>> GetClubsByConditionAsync(ClubsQueryConditions condition)
        {
            var clubs = new List<Club>();

            // 取得指定運動項目的社團
            if(condition.Sport.HasValue)
            {
                clubs = await _context.Clubs
                    .AsNoTracking()
                    .Where(c => c.Sport == condition.Sport)
                    .ToListAsync();
            }

            // 取得名稱包含指定關鍵字的社團
            if (!string.IsNullOrWhiteSpace(condition.Keyword))
            {
                var kwParam = new SqlParameter("@keyword", condition.Keyword);
                
                // 呼叫stored procedure
                clubs = await _context.Clubs
                    .FromSqlRaw("EXEC usp_GetAll_Clubs_ByKeyword @keyword", kwParam)
                    .AsNoTracking()
                    .ToListAsync();
            }

            return clubs;
        }

        public void UpdateClub(Club club)
        {
            _context.Clubs.Update(club);
        }
    }
}
