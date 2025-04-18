using SportGroups.Data.Data;
using SportGroups.Shared.Entities;
using SportGroups.Shared.Enums;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SportGroups.Data.Repositories
{
    public class ClubRepository : IClubRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateClubAsync(Club club)
        {
            await _context.Clubs.AddAsync(club);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Club?> GetClubByIdAsync(int clubId)
        {
            return await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
        }

        public async Task<bool> DeleteClubAsync(int clubId)
        {
            var existing = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existing == null)
            {
                return false;
            }
            _context.Clubs.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Club>> GetAllClubsBySportAsync(Sport sport)
        {
            return await _context.Clubs.Include(c => c.Sport == sport).ToListAsync();
        }

        public async Task<List<Club>> GetAllClubsByKeywordAsync(string keyword)
        {
            var kwParam = new SqlParameter("@keyword", keyword);
            return await _context.Clubs
                .FromSqlRaw("EXEC usp_GetAll_Clubs_ByKeyword @keyword", kwParam)
                .ToListAsync();
        }

        public async Task<bool> UpdateNameAsync(int clubId, string newName)
        {
            var existing = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existing == null)
            {
                return false;
            }
            existing.ClubName = newName;
            _context.Entry(existing).Property(c => c.ClubName).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePhoneAsync(int clubId, string newPhoneNum)
        {
            var existing = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existing == null)
            {
                return false;
            }
            existing.Phone = newPhoneNum;
            _context.Entry(existing).Property(c => c.Phone).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmailAsync(int clubId, string newEmail)
        {
            var existing = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existing == null)
            {
                return false;
            }
            existing.Email = newEmail;
            _context.Entry(existing).Property(c => c.Email).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDescrptionAsync(int clubId, string newDescription)
        {
            var existing = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existing == null)
            {
                return false;
            }
            existing.Description = newDescription;
            _context.Entry(existing).Property(c => c.Description).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
