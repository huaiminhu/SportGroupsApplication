﻿using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> ChangeAddressAsync(int eventId, string newAddress)
        {
            return await _eventRepository.UpdateAddressAsync(eventId, newAddress);
        }

        public async Task<bool> ChangeDescriptionAsync(int eventId, string newDescription)
        {
            return await _eventRepository.UpdateDescriptionAsync(eventId, newDescription);
        }

        public async Task<bool> ChangeNameAsync(int eventId, string newName)
        {
            return await _eventRepository.UpdateNameAsync(eventId, newName);
        }

        public Task<bool> CreateEventAsync(ClubEventDto clubEventDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            return await _eventRepository.DeleteEventAsync(eventId);
        }

        public Task<List<ClubEventDto>> GetAllEventByKeywordAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubEventDto>> GetAllEventsBySportAsync(Sport sport)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubEventDto>> GetAllEventsOfClubAsync(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<ClubEventDto> GetEventInfoAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
