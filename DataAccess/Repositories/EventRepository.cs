using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Shared.Enums;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly SportGroupsDbContext _context;
        public EventRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEventAsync(ClubEvent evt)
        {
            await _context.ClubEvents.AddAsync(evt);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ClubEvent?> GetEventById(int eventId)
        {
            return await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var existing = await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
            if (existing == null)
            {
                return false;
            }
            _context.ClubEvents.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<List<ClubEvent>> GetAllEventsBySportAsync(Sport sport)
        {
            // stored procedures
            throw new NotImplementedException();
        }

        public async Task<List<ClubEvent>> GetAllEventsOfClubAsync(int clubId)
        {
            return await _context.ClubEvents.Include(e => e.ClubId == clubId).ToListAsync();
        }

        public Task<List<ClubEvent>> GetAllEventsOfUserAsync(int userId)
        {
            // stored procedures
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateNameAsync(int eventId, string newName)
        {
            var existing = await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
            if (existing == null)
            {
                return false;
            }
            existing.Name = newName;
            _context.Entry(existing).Property(e => e.Name).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDescriptionAsync(int eventId, string newDescription)
        {
            var existing = await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
            if (existing == null)
            {
                return false;
            }
            existing.Name = newDescription;
            _context.Entry(existing).Property(e => e.Description).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAddressAsync(int eventId, string newAddress)
        {
            var existing = await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
            if (existing == null)
            {
                return false;
            }
            existing.Name = newAddress;
            _context.Entry(existing).Property(e => e.Address).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
