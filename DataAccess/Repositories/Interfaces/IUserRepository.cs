﻿using SportGroups.Shared.Entities;
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
        
        // 運用使用者名稱取得使用者實體
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByIdAsync(int userId);
        Task<bool> UpdateNickNameAsync(int userId, string newName);
        Task<bool> UpdatePasswordAsync(int userId, string newPassword);
    }
}
