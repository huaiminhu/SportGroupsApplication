using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly SportGroupsDbContext _context;
        public UserRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> GetUserAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<bool> UpdateNickNameAsync(Guid userId, string newName)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (existing == null)
            {
                return false ;
            }
            existing.NickName = newName;
            _context.Entry(existing).Property(u => u.NickName).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePasswordAsync(Guid userId, string newPassword)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (existing == null)
            {
                return false;
            }
            existing.PasswordHash = newPassword;
            _context.Entry(existing).Property(u => u.PasswordHash).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
