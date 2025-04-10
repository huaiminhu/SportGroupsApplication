using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IEventService
    {
        Task<bool> CreateEventAsync(ClubEventDto clubEventDto);
        Task<ClubEventDto> GetEventInfoAsync(int id);
        
        // 取得使用指定運動項目所有活動
        Task<List<ClubEventDto>> GetAllEventsBySportAsync(Sport sport);
        
        // 取得指定社團所有活動
        Task<List<ClubEventDto>> GetAllEventsOfClubAsync(int clubId);
        
        // 取得指定關鍵字所有活動
        Task<List<ClubEventDto>> GetAllEventByKeywordAsync(string keyword);
        Task<bool> ChangeNameAsync(int eventId, string newName);
        Task<bool> ChangeDescriptionAsync(int eventId, string newDescription);
        Task<bool> ChangeAddressAsync(int eventId, string newAddress);
        Task<bool> DeleteEventAsync(int eventId);
    }
}
