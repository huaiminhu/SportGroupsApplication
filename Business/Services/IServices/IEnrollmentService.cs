using SportGroups.Shared.DTOs.EnrollmentDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IEnrollmentService
    {
        // 參加社團活動
        Task<bool> AttendEventAsync(NewEnrollmentDto newEnrollmentDto);
        Task<EnrollmentInfoDto?> GetEnrollmentByIdAsync(int userId, int eventId);
        // 取得使用者所有報名
        Task<List<EnrollmentInfoDto>> GetAllEnrollmentsOfUserAsync(int userId);
    }
}
