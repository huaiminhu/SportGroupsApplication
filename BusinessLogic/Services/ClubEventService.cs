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
    public class ClubEventService : IClubEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClubEventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ChangeAddressAsync(int eventId, string newAddress)
        {
            return await _unitOfWork.ClubEvents.UpdateAddressAsync(eventId, newAddress);
        }

        public async Task<bool> ChangeDescriptionAsync(int eventId, string newDescription)
        {
            return await _unitOfWork.ClubEvents.UpdateDescriptionAsync(eventId, newDescription);
        }

        public async Task<bool> ChangeNameAsync(int eventId, string newName)
        {
            return await _unitOfWork.ClubEvents.UpdateNameAsync(eventId, newName);
        }

        public async Task<bool> CreateEventAsync(NewEventDto newEventDto)
        {
            var newEvent = _mapper.Map<ClubEvent>(newEventDto);
            return await _unitOfWork.ClubEvents.CreateEventAsync(newEvent);
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            return await _unitOfWork.ClubEvents.DeleteEventAsync(eventId);
        }

        public async Task<List<EventInfoDto>> GetAllEventByKeywordAsync(string keyword)
        {
            var events = await _unitOfWork.ClubEvents.GetAllEventsByKeywordAsync(keyword);
            return _mapper.Map<List<EventInfoDto>>(events);
        }

        public async Task<List<EventInfoDto>> GetAllEventsBySportAsync(Sport sport)
        {
            var events = await _unitOfWork.ClubEvents.GetAllEventsBySportAsync(sport);
            return _mapper.Map<List<EventInfoDto>>(events);
        }

        public async Task<List<EventInfoDto>> GetAllEventsOfClubAsync(int clubId)
        {
            var events = await _unitOfWork.ClubEvents.GetAllEventsOfClubAsync(clubId);
            return _mapper.Map<List<EventInfoDto>>(events);
        }

        public async Task<EventInfoDto> GetEventInfoAsync(int eventId)
        {
            var info = await _unitOfWork.ClubEvents.GetEventByIdAsync(eventId);
            return _mapper.Map<EventInfoDto>(info);
        }
    }
}
