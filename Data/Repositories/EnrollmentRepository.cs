using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;

namespace SportGroups.Data.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {

        private readonly SportGroupsDbContext _context;
        public EnrollmentRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task AddEnrollmentAsync(int userId, int eventId, string phone, DateTime enrollDate)
        {
            //var uIdParam = new SqlParameter("@userId", userId);
            //var eIdParam = new SqlParameter("@eventId", eventId);
            //var phoneParam = new SqlParameter("@phone", phone);
            //var dateParam = new SqlParameter("@enrollDate", enrollDate);

            //// 呼叫stored procedure
            //await _context.Database
            //    .ExecuteSqlRawAsync(
            //    "EXEC usp_Create_Enrollments_AddEnrollment @userId, @eventId, @phone, @enrollDate",
            //    uIdParam, eIdParam, phoneParam, dateParam);

            await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Create_Enrollments_AddEnrollment {userId}, {eventId}, {phone}, {enrollDate}"
                );
        }

        public async Task<Enrollment?> GetEnrollmentByIdAsync(int userId, int eventId)
        {
            return await _context.Enrollments
                .FirstOrDefaultAsync(e => e.UserId == userId && e.ClubEventId == eventId);
        }

        public async Task<List<Enrollment>> GetAllEnrollmentOfUserAsync(int userId)
        {
            var uIdParam = new SqlParameter("@userId", userId);

            // 呼叫stored procedure
            return await _context.Enrollments
                .FromSqlRaw("EXEC usp_GetAll_Enrollments_OfUser @userId", uIdParam)
                .ToListAsync();
        }

        public async Task UpdateEnrollmentAsync(int userId, int eventId, string? phone)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Update_Enrollments_UpdateEnrollment {userId}, {eventId}, {phone}"
                );
        }

        public async Task DeleteEnrollmentAsync(int userId, int eventId)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Delete_Enrollments_DeleteEnrollment {userId}, {eventId}"
                );
        }
    }
}
