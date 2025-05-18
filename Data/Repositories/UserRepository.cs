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

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }
        //public async Task<bool> UpdateNickNameAsync(int userId, string newName)
        //{
        //    var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        //    if (existing == null)
        //    {
        //        return false ;
        //    }
        //    existing.NickName = newName;
        //    _context.Entry(existing).Property(u => u.NickName).IsModified = true;
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> UpdatePasswordAsync(int userId, string newPassword)
        //{
        //    var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    existing.PasswordHash = newPassword;
        //    _context.Entry(existing).Property(u => u.PasswordHash).IsModified = true;
        //    return await _context.SaveChangesAsync() > 0;
        //}
    }
}
