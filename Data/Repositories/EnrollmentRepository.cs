﻿using Microsoft.Data.SqlClient;
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

        public async Task<int> AddEnrollmentAsync(int userId, int eventId, string phone, DateTime enrollDate)
        {
            // 呼叫stored procedure
            return await _context.Database
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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> UpdateEnrollmentAsync(int userId, int eventId, string? phone)
        {
            // 呼叫stored procedure
            return await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Update_Enrollments_UpdateEnrollment {userId}, {eventId}, {phone}"
                );
        }

        public async Task<int> DeleteEnrollmentAsync(int userId, int eventId)
        {
            // 呼叫stored procedure
            return await _context.Database
                .ExecuteSqlInterpolatedAsync(
                $"EXEC usp_Delete_Enrollments_DeleteEnrollment {userId}, {eventId}"
                );
        }
    }
}
