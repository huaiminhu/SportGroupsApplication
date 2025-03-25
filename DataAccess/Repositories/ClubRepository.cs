using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
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

        public async Task<Club?> GetClubById(int clubId)
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

        public async Task<bool> UpdateNameAsync(int clubId, string newName)
        {
            var existing = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existing == null)
            {
                return false;
            }
            existing.Name = newName;
            _context.Entry(existing).Property(c => c.Name).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePhoneAsync(int clubId, string newPhoneNum)
        {
            var existing = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existing == null)
            {
                return false;
            }
            existing.Name = newPhoneNum;
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
            existing.Name = newEmail;
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
            existing.Name = newDescription;
            _context.Entry(existing).Property(c => c.Description).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
