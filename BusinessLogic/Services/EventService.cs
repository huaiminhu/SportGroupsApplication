using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Shared.Entities;
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
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
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

        public async Task<bool> CreateEventAsync(NewEventDto newEventDto)
        {
            var newEvent = _mapper.Map<ClubEvent>(newEventDto);
            return await _eventRepository.CreateEventAsync(newEvent);
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            return await _eventRepository.DeleteEventAsync(eventId);
        }

        public async Task<List<EventInfoDto>> GetAllEventByKeywordAsync(string keyword)
        {
            var events = await _eventRepository.GetAllEventsByKeywordAsync(keyword);
            return _mapper.Map<List<EventInfoDto>>(events);
        }

        public async Task<List<EventInfoDto>> GetAllEventsBySportAsync(Sport sport)
        {
            var events = await _eventRepository.GetAllEventsBySportAsync(sport);
            return _mapper.Map<List<EventInfoDto>>(events);
        }

        public async Task<List<EventInfoDto>> GetAllEventsOfClubAsync(int clubId)
        {
            var events = await _eventRepository.GetAllEventsOfClubAsync(clubId);
            return _mapper.Map<List<EventInfoDto>>(events);
        }

        public async Task<EventInfoDto> GetEventInfoAsync(int eventId)
        {
            var info = await _eventRepository.GetEventByIdAsync(eventId);
            return _mapper.Map<EventInfoDto>(info);
        }
    }
}
