﻿using SportGroups.Shared.DTOs.ClubEventDTOs;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IClubEventService
    {
        Task<int?> CreateEventAsync(NewEventDto newEventDto);
        Task<EventInfoDto> GetEventInfoAsync(int eventId);

        // 依條件取得指定活動
        Task<List<EventInfoDto>> GetEventsByConditionAsync(EventsQueryConditions condition);
        
        //// 取得使用指定運動項目所有活動
        //Task<List<EventInfoDto>> GetAllEventsBySportAsync(Sport sport);
        
        //// 取得指定社團所有活動
        //Task<List<EventInfoDto>> GetAllEventsOfClubAsync(int clubId);
        
        //// 取得指定關鍵字所有活動
        //Task<List<EventInfoDto>> GetAllEventByKeywordAsync(string keyword);
        Task<bool> UpdateEventAsync(int eventId, EventUpdateDto eventUpdateDto);
        //Task<bool> ChangeNameAsync(int eventId, string newName);
        //Task<bool> ChangeDescriptionAsync(int eventId, string newDescription);
        //Task<bool> ChangeAddressAsync(int eventId, string newAddress);
        Task<bool> DeleteEventAsync(int eventId);
    }
}
