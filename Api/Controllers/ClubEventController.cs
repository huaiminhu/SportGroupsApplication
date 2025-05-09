using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ClubEventDTOs;
using SportGroups.Shared.DTOs.EventDTOs;
using SportGroups.Shared.Enums;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubEventController : ControllerBase
    {
        private readonly IClubEventService _clubEventService;
        public ClubEventController(IClubEventService clubEventService)
        {
            _clubEventService = clubEventService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent(NewEventDto newEventDto)
        {
            var result = await _clubEventService.CreateEventAsync(newEventDto);
            return result ? CreatedAtAction(nameof(ClubEventController.GetEventInfo), "ClubEvent", new { }, result) : BadRequest();
        }

        [HttpPost("eventinfo")]
        public async Task<ActionResult<EventInfoDto>> GetEventInfo([FromBody]int eventId)
        {
            var info = await _clubEventService.GetEventInfoAsync(eventId);
            if(info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        [HttpPost("getalleventsbysport")]
        public async Task<ActionResult<List<EventInfoDto>>> GetAllEventsBySport(Sport sport)
        {
            var events = await _clubEventService.GetAllEventsBySportAsync(sport);
            if(events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpPost("getalleventsofclub")]
        public async Task<ActionResult<List<EventInfoDto>>> GettAllEventOfClub([FromBody]int clubId)
        {
            var clubs = await _clubEventService.GetAllEventsOfClubAsync(clubId);
            if(clubs == null)
            {
                return NotFound();
            }
            return Ok(clubs);
        }

        [HttpPost("getalleventsbykeyword")]
        public async Task<ActionResult<List<EventInfoDto>>> GetAllEventsByKeyword([FromBody]string keyword)
        {
            var events = await _clubEventService.GetAllEventByKeywordAsync(keyword);
            if(events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateEvent(EventUpdateDto eventUpdateDto)
        {
            var result = await _clubEventService.UpdateEventAsync(eventUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteEvent([FromBody]int eventId)
        {
            var result = await _clubEventService.DeleteEventAsync(eventId);
            return result ? NoContent() : BadRequest();
        }
    }
}
