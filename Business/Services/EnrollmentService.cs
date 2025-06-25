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

        public async Task<ResultDto<EnrollmentInfoDto>> AttendEventAsync(NewEnrollmentDto newEnrollmentDto)
        {
            var uId = newEnrollmentDto.UserId;
            var eId = newEnrollmentDto.ClubEventId;

            // 防止重複報名
            var existing = await _unitOfWork.Enrollments
                .GetEnrollmentByIdAsync(uId, eId);
            if (existing != null) 
            {
                return new ResultDto<EnrollmentInfoDto>
                {
                    IsSuccess = false, 
                    ResponseMessage = "請勿重複報名!"
                };
            }

            var phone = newEnrollmentDto.Phone;
            var enrollDate = DateTime.Now;

            // 因AddEnrollmentAsync不透過Entity操作資料沒有回傳值
            // 由此處設置例外處理以回傳ResultDto
            try
            {
                await _unitOfWork.Enrollments.AddEnrollmentAsync(uId, eId, phone, enrollDate);
                return new ResultDto<EnrollmentInfoDto> 
                {
                    IsSuccess = true, 
                    ResponseMessage = "報名成功!"
                };
            }
            catch
            {
                return new ResultDto<EnrollmentInfoDto>
                {
                    IsSuccess = false,
                    ResponseMessage = "報名失敗!"
                };
            }
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
    }
}
