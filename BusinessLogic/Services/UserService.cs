using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.UserDTOs;
using SportGroups.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ChangeNickNameAsync(int userId, string newName)
        {
            return await _unitOfWork.Users.UpdateNickNameAsync(userId, newName);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string newPassword)
        {
            return await _unitOfWork.Users.UpdatePasswordAsync(userId, newPassword);
        }

        public async Task<UserInfoDto> GetUserByUsernameAsync(string username)
        {
            var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
            return _mapper.Map<UserInfoDto>(user);
        }

        public async Task<UserInfoDto> GetUserByIdAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            return _mapper.Map<UserInfoDto>(user);
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            registerDto.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            var newUser = _mapper.Map<User>(registerDto);
            newUser.RegisterDate = DateTime.Now;
            return await _unitOfWork.Users.CreateUserAsync(newUser);
        }
    }
}
