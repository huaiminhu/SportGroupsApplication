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

        public async Task<bool> UpdateUserAsync(int userId, UserUpdateDto userUpdateDto)
        {
            var existing = await _unitOfWork.Users.GetUserByIdAsync(userId);
            if(existing == null)
            {
                return false;
            }

            // 修改密碼
            if(!BCrypt.Net.BCrypt.Verify(userUpdateDto.Password, existing.PasswordHash))
            {
                userUpdateDto.Password = BCrypt.Net.BCrypt.HashPassword(userUpdateDto.Password);
            }

            _mapper.Map(userUpdateDto, existing);
            _unitOfWork.Users.UpdateUser(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<UserInfoDto> GetUserByIdAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            return _mapper.Map<UserInfoDto>(user);
        }
    }
}
