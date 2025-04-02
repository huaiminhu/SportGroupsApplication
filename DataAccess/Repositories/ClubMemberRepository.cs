using Microsoft.Data.SqlClient;
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

        public async Task<bool> AddMemberAsync(ClubMember member)
        {
            await _context.ClubMembers.AddAsync(member);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Club>> GetAllClubsOfUserAsync(Guid userId)
        {
            var uIdParam = new SqlParameter("@userId", userId);
            return await _context.Clubs
                .FromSqlRaw("EXEC usp_GetAll_ClubsOfUser @userId", uIdParam)
                .ToListAsync();
        }
    }
}
