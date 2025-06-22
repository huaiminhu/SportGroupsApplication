using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ClubEventDTOs;

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

        public async Task<bool> UpdateEventAsync(int eventId, EventUpdateDto eventUpdateDto)
        {
            var existing = await _unitOfWork.ClubEvents.GetEventByIdAsync(eventId);
            if (existing == null)
            {
                return false;
            }
            _mapper.Map(eventUpdateDto, existing);
            _unitOfWork.ClubEvents.UpdateEvent(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int?> CreateEventAsync(NewEventDto newEventDto)
        {
            var newEvent = _mapper.Map<ClubEvent>(newEventDto);
            await _unitOfWork.ClubEvents.CreateEventAsync(newEvent);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0 ? newEvent.ClubEventId : null;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var existing = await _unitOfWork.ClubEvents.GetEventByIdAsync(eventId);
            if (existing == null)
            {
                return false;
            }
            _unitOfWork.ClubEvents.DeleteEvent(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<List<EventInfoDto>> GetEventsByConditionAsync(EventsQueryConditions condition)
        {
            var events = await _unitOfWork.ClubEvents.GetEventsByConditionAsync(condition);
            return _mapper.Map<List<EventInfoDto>>(events);
        }

        public async Task<EventInfoDto> GetEventInfoAsync(int eventId)
        {
            var info = await _unitOfWork.ClubEvents.GetEventByIdAsync(eventId);
            return _mapper.Map<EventInfoDto>(info);
        }
    }
}
