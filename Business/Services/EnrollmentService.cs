using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.EnrollmentDTOs;
using SportGroups.Shared.DTOs.ResultDTOs;

namespace SportGroups.Business.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultDto> AttendEventAsync(int userId, NewEnrollmentDto newEnrollmentDto)
        {
            var eId = newEnrollmentDto.ClubEventId;

            // 防止重複報名
            var existing = await _unitOfWork.Enrollments
                .GetEnrollmentByIdAsync(userId, eId);
            if (existing != null) 
            {
                return new ResultDto
                {
                    IsSuccess = false, 
                    ResponseMessage = "請勿重複報名!"
                };
            }

            var phone = newEnrollmentDto.Phone;
            var enrollDate = DateTime.Now;

            // 報名
            var result = await _unitOfWork.Enrollments
                .AddEnrollmentAsync(userId, eId, phone, enrollDate);
            if(result == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "報名失敗!"
                };
            }
            return new ResultDto
            {
                IsSuccess = true,
                ResponseMessage = "報名成功!"
            };
        }

        public async Task<EnrollmentInfoDto?> GetEnrollmentByIdAsync(int userId, int eventId)
        {
            var enrollment = await _unitOfWork.Enrollments.GetEnrollmentByIdAsync(userId, eventId);
            return _mapper.Map<EnrollmentInfoDto>(enrollment);
        }

        public async Task<List<EnrollmentInfoDto>> GetAllEnrollmentsOfUserAsync(int userId)
        {
            var enrollment = await _unitOfWork.Enrollments.GetAllEnrollmentOfUserAsync(userId);
            return _mapper.Map<List<EnrollmentInfoDto>>(enrollment);
        }

        public async Task<ResultDto> UpdateEnrollmentAsync(int userId, EnrollmentUpdateDto enrollmentUpdateDto)
        {
            var enrollment = await _unitOfWork.Enrollments
                .GetEnrollmentByIdAsync(userId, enrollmentUpdateDto.ClubEventId);
            if(enrollment == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "找不到報名資訊!"
                };
            }

            // 更新報名資訊
            var result = await _unitOfWork.Enrollments
                .UpdateEnrollmentAsync(userId, enrollmentUpdateDto.ClubEventId, enrollmentUpdateDto.Phone);
            if (result == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "更新失敗!"
                };
            }
            return new ResultDto
            {
                IsSuccess = true,
                ResponseMessage = "更新成功!"
            };
        }

        public async Task<ResultDto> CancelEnrollmentAsync(int userId, int eventId)
        {
            var enrollment = await _unitOfWork.Enrollments
                .GetEnrollmentByIdAsync(userId, eventId);
            if (enrollment == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "找不到報名資訊!"
                };
            }

            // 取消報名
            var result = await _unitOfWork.Enrollments
                    .DeleteEnrollmentAsync(userId, eventId);
            if (result == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "刪除失敗!"
                };
            }
            return new ResultDto
            {
                IsSuccess = true,
                ResponseMessage = "刪除成功!"
            };
        }
    }
}
