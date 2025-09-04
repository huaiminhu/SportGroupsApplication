using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.UserDTOs;
using SportGroups.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SportGroups.Shared.Configurations;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using SportGroups.Shared.DTOs.ResultDTOs;
using SportGroups.Shared.Enums;

namespace SportGroups.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings; // JWT設定
        public AuthService(IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IOptions<JwtSettings> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtSettings = options.Value;
        }

        public async Task<ResultDto> RegisterAsync(RegisterDto registerDto)
        {
            // 檢查使用者名稱是否已存在於資料庫
            var existing = await _unitOfWork.Users.GetUserByUsernameAsync(registerDto.UserName);
            if (existing != null)
            {
                return new ResultDto
                {
                    IsSuccess = false, 
                    ResponseMessage = "這個使用者名稱有人使用了!再換一個~"
                };
            }
            
            // DTO轉Entity
            var newUser = _mapper.Map<User>(registerDto);

            // 對密碼進行雜湊處理
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            newUser.RegisterDate = DateTime.Now;

            // 使用UnitOfWork管理的User Repository新增使用者
            await _unitOfWork.Users.CreateUserAsync(newUser);
            await _unitOfWork.SaveChangesAsync();

            // 給前端的Response
            return new ResultDto
            {
                IsSuccess = true,
                ResponseMessage = "註冊成功!", 
            };
        }

        public async Task<UserInfoDto?> AuthAsync(LoginDto loginDto)
        {
            // 驗證從前端傳來的密碼經雜湊處理後是否與資料庫裡儲存的密碼是否一致
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(loginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return null;
            }

            // 生成新Token
            var token = NewToken(user);

            // 生成更新的Token
            user.RefreshToken = GenerateRefreshToken();

            // 設定更新的Token過期時效
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            // 使用UnitOfWork管理的User Repository更新使用者
            _unitOfWork.Users.UpdateUser(user);

            // 經Auto Mapper轉換成DTO後回傳
            var info = _mapper.Map<UserInfoDto>(user);
            info.Token = token;

            return info;
        }

        public async Task<UserInfoDto?> RefreshTokenAsync(string refreshToken)
        {
            var user = await _unitOfWork.Users.GetUserByRefreshTokenAsync(refreshToken);
            if (user == null)
            {
                return null;
            }

            var token = NewToken(user);

            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            _unitOfWork.Users.UpdateUser(user);

            var info = _mapper.Map<UserInfoDto>(user);
            info.Token = token;

            return info;
        }

        // 生成新Token
        public string NewToken(User user)
        {
            // 設定Claim資訊
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()), 
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName), 
                new Claim(ClaimTypes.Name, user.UserName), 
                new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // 設定對稱安全金鑰
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            
            // 設定數位簽章
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 設定Token
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            // 回傳Token字串
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // 生成更新的Token
        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
