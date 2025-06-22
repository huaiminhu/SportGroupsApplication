using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ClubEventDTOs;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IClubEventRepository
    {
        Task CreateEventAsync(ClubEvent clubEvent);
        Task<ClubEvent?> GetEventByIdAsync(int eventId);

        // 依條件取得指定活動
        Task<List<ClubEvent>> GetEventsByConditionAsync(EventsQueryConditions condition);
        void UpdateEvent(ClubEvent clubEvent);
        void DeleteEvent(ClubEvent clubEvent);
    }
}
