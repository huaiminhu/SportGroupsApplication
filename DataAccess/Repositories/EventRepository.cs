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

        public Task CreateEvent(ClubEvent evt)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubEvent>> GetAllEventsBySport(Sport sport)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEvent(ClubEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}
