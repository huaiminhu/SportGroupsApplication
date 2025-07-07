using SportGroups.Data.Entities;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        // 新增活動報名
        Task<int> AddEnrollmentAsync(int userId, int eventId, string phone, DateTime enrollDate);
        Task<Enrollment?> GetEnrollmentByIdAsync(int userId, int eventId);
        Task<List<Enrollment>> GetAllEnrollmentOfUserAsync(int userId);
        Task<int> UpdateEnrollmentAsync(int userId, int eventId, string? phone);
        Task<int> DeleteEnrollmentAsync(int userId, int eventId);
    }
}
