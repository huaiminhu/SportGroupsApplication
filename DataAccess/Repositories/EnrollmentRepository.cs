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

        public Task<bool> AddEnrollmentAsync(Guid userId, int eventId)
        {
            // stored procedures
            throw new NotImplementedException();
        }

        public Task<Enrollment?> GetEnrollmentInfo(Guid userId, int eventId)
        {
            // stored procedures
            throw new NotImplementedException();
        }
    }
}
