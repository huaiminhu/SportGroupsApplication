using Microsoft.EntityFrameworkCore;
using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories
{
    public class ClubMemberRepository : IClubMemberRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubMemberRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMemberAsync(Guid userId, int clubId, string email, DateTime joinTime)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Add_ClubMember @p0, @p1, @p2, @p3", userId, clubId, email, joinTime);
            return true;
        }

        public async Task<List<Club>> GetAllClubsOfUserAsync(Guid userId)
        {
            return await _context.Clubs
                .FromSqlRaw("EXEC usp_GetAll_ClubsOfUser @p0", userId)
                .ToListAsync();
        }
    }
}
