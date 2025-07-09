using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

            // 取得指定ClubId的活動
            if (condition.ClubId.HasValue)
            {
                events = await _context.ClubEvents.Where(e => e.ClubId == condition.ClubId).ToListAsync();
            }

            // 取得指定運動項目的活動
            if (condition.Sport.HasValue)
            {
                return events = await _context.ClubEvents
                    .Where(e => e.Sport == condition.Sport)
                    .ToListAsync();
            }

            // 取得標題包含指定關鍵字的活動
            if (!string.IsNullOrWhiteSpace(condition.Keyword))
            {
                var keywordParam = new SqlParameter("@keyword", condition.Keyword);

                // 呼叫stored procedure
                events = await _context.ClubEvents
                    .FromSqlRaw("EXEC usp_GetAll_ClubEvents_ByKeyword @keyword", keywordParam)
                    .ToListAsync();
            }

            return events;
        }

        public void UpdateEvent(ClubEvent clubEvent)
        {
            _context.ClubEvents.Update(clubEvent);
        }
    }
}
