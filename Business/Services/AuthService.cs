using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.UserDTOs;
using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SportGroups.Shared.Configurations;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace SportGroups.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;
        public AuthService(IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IOptions<JwtSettings> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtSettings = options.Value;
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            registerDto.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            var newUser = _mapper.Map<User>(registerDto);
            newUser.RegisterDate = DateTime.Now;
            await _unitOfWork.Users.CreateUserAsync(newUser);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<UserInfoDto?> AuthAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(loginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
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

        public async Task<UserInfoDto?> RefreshTokenAsync(string refreshToken)
        {
            var user = await _unitOfWork.Users.GetByRefreshTokenAsync(refreshToken);
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

        public string NewToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()), 
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName), 
                new Claim(ClaimTypes.Name, user.UserName), 
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
