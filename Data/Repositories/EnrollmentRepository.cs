using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var uIdParam = new SqlParameter("@userId", userId);
            var eIdParam = new SqlParameter("@eventId", eventId);
            var phoneParam = new SqlParameter("@phone", phone);
            var dateParam = new SqlParameter("@enrollDate", enrollDate);
            await _context.Database
                .ExecuteSqlRawAsync(
                "EXEC usp_Create_Enrollments_AddEnrollment @userId, @eventId, @phone, @enrollDate",
                uIdParam, eIdParam, phoneParam, dateParam);
        }

        public async Task<Enrollment?> GetEnrollmentByIdAsync(int userId, int eventId)
        {
            //var uIdParam = new SqlParameter("@userId", userId);
            //var eIdParam = new SqlParameter("@eventId", eventId);
            return await _context.Enrollments
                .FirstOrDefaultAsync(e => e.UserId == userId && e.ClubEventId == eventId);
                //.FromSqlRaw("EXEC usp_Get_Enrollments_ById @userId, @eventId", uIdParam, eIdParam)
                //.FirstOrDefaultAsync();
        }

        public async Task<List<Enrollment>> GetAllEnrollmentOfUserAsync(int userId)
        {
            var uIdParam = new SqlParameter("userId", userId);
            return await _context.Enrollments
                .FromSqlRaw("EXEC usp_GetAll_Enrollment_OfUser @userId", uIdParam)
                .ToListAsync();
        }
    }
}
