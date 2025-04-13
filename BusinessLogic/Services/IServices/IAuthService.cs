using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IAuthService
    {
        // 註冊
        Task<bool> RegisterAsync(RegisterDto registerDto);
        
        // 驗證使用者
        Task<UserDto?> AuthAsync(string username, string password);
    }
}
