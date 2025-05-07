using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IAuthService
    {   
        // 驗證使用者
        Task<UserInfoDto?> AuthAsync(LoginDto loginDto);
    }
}
