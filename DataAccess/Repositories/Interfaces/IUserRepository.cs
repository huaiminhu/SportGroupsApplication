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
        Task<bool> CreateUserAsync(User user);
        Task<User?> GetUserAsync(string username);
        Task<bool> UpdateNickNameAsync(Guid userId, string newName);
        
        // 更改密碼
        Task<bool> UpdatePasswordAsync(Guid userId, string newPassword);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
