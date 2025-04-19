using SportGroups.Shared.Entities;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<bool> CreateEventAsync(ClubEvent evt);
        Task<ClubEvent?> GetEventByIdAsync(int eventId);

        // 取得指定運動項目類別的所有活動
        Task<List<ClubEvent>> GetAllEventsBySportAsync(Sport sport);

        // 取得指定社團所有活動
        Task<List<ClubEvent>> GetAllEventsOfClubAsync(int clubId);
        
        // 取得使用者報名的所有活動
        Task<List<ClubEvent>> GetAllEventsOfUserAsync(Guid userId);

        // 取得包含指定關鍵字的所有活動
        Task<List<ClubEvent>> GetAllEventsByKeywordAsync(string keyword);
        Task<bool> UpdateNameAsync(int eventId, string newName);
        Task<bool> UpdateDescriptionAsync(int eventId, string newDescription);
        Task<bool> UpdateAddressAsync(int eventId, string newAddress);
        Task<bool> DeleteEventAsync(int eventId);
    }
}
