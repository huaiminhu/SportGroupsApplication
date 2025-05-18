using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        
        // 運用使用者名稱取得使用者實體
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByIdAsync(int userId);
        void UpdateUser(User user);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
        //Task<bool> UpdateNickNameAsync(int userId, string newName);
        //Task<bool> UpdatePasswordAsync(int userId, string newPassword);
    }
}
