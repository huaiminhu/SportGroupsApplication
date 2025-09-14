using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.UserDTOs;

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

        public async Task<bool> ChangePasswordAsync(int userId, string password)
        {
            var existing = await _unitOfWork.Users.GetUserByIdAsync(userId);
            if (existing == null)
            {
                return false;
            }

            // 更改密碼
            existing.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            _unitOfWork.Users.UpdateUser(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> ChangeNickNameAsync(int userId, string nickname)
        {
            var existing = await _unitOfWork.Users.GetUserByIdAsync(userId);
            if (existing == null)
            {
                return false;
            }

            // 更改暱稱
            existing.NickName = nickname;
            _unitOfWork.Users.UpdateUser(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<UserInfoDto?> GetUserInfoAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            return _mapper.Map<UserInfoDto>(user);
        }
    }
}
