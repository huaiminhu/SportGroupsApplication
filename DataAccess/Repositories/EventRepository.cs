using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly SportGroupsDbContext _context;
        public EventRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public Task CreateEventAsync(ClubEvent evt)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEventAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubEvent>> GetAllEventsBySportAsync(Sport sport)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEventAsync(ClubEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}
