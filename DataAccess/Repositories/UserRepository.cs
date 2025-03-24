using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
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

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (existing == null) 
            {
                return false;
            }
            _context.Users.Remove(existing);
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
            existing.Password = newPassword;
            _context.Entry(existing).Property(u => u.Password).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
