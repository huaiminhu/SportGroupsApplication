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
        Task<List<ClubEventDto>> GetAllEventsBySportAsync(Sport sport);
        Task<List<ClubEventDto>> GetAllEventsOfClubAsync(int clubId);
        Task<List<ClubEventDto>> GetAllEventByKeywordAsync(string keyword);
        Task<bool> ChangeNameAsync(int eventId, string newName);
        Task<bool> ChangeDescriptionAsync(int eventId, string newDescription);
        Task<bool> ChangeAddressAsync(int eventId, string newAddress);
        Task<bool> DeleteEventAsync(int eventId);
    }
}
