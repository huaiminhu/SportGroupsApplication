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

        public async Task<bool> AddEnrollmentAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Enrollment?> GetEnrollmentInfo(Guid userId, int eventId)
        {
            var uIdParam = new SqlParameter("@uId", userId);
            var eIdParam = new SqlParameter("@eId", eventId);
            return await _context.Enrollments
                .FromSqlRaw("EXEC usp_Get_EnrollmentInfo @uId, @eId", uIdParam, eIdParam)
                .FirstOrDefaultAsync();
        }
    }
}
