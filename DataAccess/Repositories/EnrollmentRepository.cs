using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {

        private readonly SportGroupsDbContext _context;
        public EnrollmentRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public Task AttendEventAsync(int userId, int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubEvent>> GetAllEventsOfClubAsync(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubEvent>> GetAllEventsOfUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
