using SportGroups.Shared.DTOs.ClubEventDTOs;
using SportGroups.Shared.DTOs.EventDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubEventService
    {
        Task<int?> CreateEventAsync(NewEventDto newEventDto);
        Task<EventInfoDto> GetEventInfoAsync(int eventId);

        // 依指定條件取得活動
        Task<List<EventInfoDto>> GetEventsByConditionAsync(EventsQueryConditions condition);
        Task<bool> UpdateEventAsync(int eventId, EventUpdateDto eventUpdateDto);
        Task<bool> DeleteEventAsync(int eventId);
    }
}
