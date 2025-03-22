using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User user);
        Task<User?> GetUserAsync(string username);
        Task<bool> ChangeNickNameAsync(Guid userId, string newName);
        Task<bool> ChangePasswordAsync(Guid userId, string newPassword);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
