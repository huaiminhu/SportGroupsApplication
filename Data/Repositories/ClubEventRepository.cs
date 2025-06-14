﻿using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Shared.Enums;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SportGroups.Shared.DTOs.ClubEventDTOs;

namespace SportGroups.Data.Repositories
{
    public class ClubEventRepository : IClubEventRepository
    {

        private readonly SportGroupsDbContext _context;
        public ClubEventRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(ClubEvent clubEvent)
        {
            await _context.ClubEvents.AddAsync(clubEvent);
        }

        public async Task<ClubEvent?> GetEventByIdAsync(int eventId)
        {
            return await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
        }

        public void DeleteEvent(ClubEvent clubEvent)
        {
            _context.ClubEvents.Remove(clubEvent);
        }

        public async Task<List<ClubEvent>> GetEventsByConditionAsync(EventsQueryConditions condition)
        {
            var events = new List<ClubEvent>();

            if (condition.ClubId.HasValue)
            {
                events = await _context.ClubEvents.Where(e => e.ClubId == condition.ClubId).ToListAsync();
            }

            if (condition.Sport.HasValue)
            {
                var sportParam = new SqlParameter("@sport", condition.Sport);
                events = await _context.ClubEvents
                    .FromSqlRaw("EXEC usp_GetAll_ClubEvents_BySport @sport", sportParam)
                    .ToListAsync();
            }

            if (!string.IsNullOrWhiteSpace(condition.Keyword))
            {
                var keywordParam = new SqlParameter("@keyword", condition.Keyword);
                events = await _context.ClubEvents
                    .FromSqlRaw("EXEC usp_GetAll_ClubEvents_ByKeyword @keyword", keywordParam)
                    .ToListAsync();
            }

            return events;
        }

        //public async Task<List<ClubEvent>> GetAllEventsBySportAsync(Sport sport)
        //{
        //    var sportParam = new SqlParameter("@sport", sport);
        //    return await _context.ClubEvents
        //        .FromSqlRaw("EXEC usp_GetAll_ClubEvents_BySport @sport", sportParam)
        //        .ToListAsync();
        //}

        //public async Task<List<ClubEvent>> GetAllEventsOfClubAsync(int clubId)
        //{
        //    return await _context.ClubEvents.Include(e => e.ClubId == clubId).ToListAsync();
        //}

        //public async Task<List<ClubEvent>> GetAllEventsOfUserAsync(Guid userId)
        //{
        //    var uIdParam = new SqlParameter("@userId", userId);
        //    return await _context.ClubEvents
        //        .FromSqlRaw("EXEC usp_GetAll_ClubEvents_OfUser @userId", uIdParam)
        //        .ToListAsync();
        //}

        //public async Task<List<ClubEvent>> GetAllEventsByKeywordAsync(string keyword)
        //{
        //    var keywordParam = new SqlParameter("@keyword", keyword);
        //    return await _context.ClubEvents
        //        .FromSqlRaw("EXEC usp_GetAll_ClubEvents_ByKeyword @keyword", keywordParam)
        //        .ToListAsync();
        //}

        public void UpdateEvent(ClubEvent clubEvent)
        {
            _context.ClubEvents.Update(clubEvent);
        }

        //public async Task<bool> UpdateNameAsync(int eventId, string newName)
        //{
        //    var existing = await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    existing.EventName = newName;
        //    _context.Entry(existing).Property(e => e.EventName).IsModified = true;
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> UpdateDescriptionAsync(int eventId, string newDescription)
        //{
        //    var existing = await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    existing.Description = newDescription;
        //    _context.Entry(existing).Property(e => e.Description).IsModified = true;
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> UpdateAddressAsync(int eventId, string newAddress)
        //{
        //    var existing = await _context.ClubEvents.FirstOrDefaultAsync(e => e.ClubEventId == eventId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    existing.Address = newAddress;
        //    _context.Entry(existing).Property(e => e.Address).IsModified = true;
        //    return await _context.SaveChangesAsync() > 0;
        //}
    }
}
