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
    public class ClubEventsController : ControllerBase
    {
        private readonly IClubEventService _clubEventService;
        public ClubEventsController(IClubEventService clubEventService)
        {
            _clubEventService = clubEventService;
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] NewEventDto newEventDto)
        {
            var result = await _clubEventService.CreateEventAsync(newEventDto);
            return result ? CreatedAtAction(nameof(ClubEventsController.GetEventInfo), "ClubEvent", new { }, result) : BadRequest();
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventInfoDto>> GetEventInfo(int eventId)
        {
            var info = await _clubEventService.GetEventInfoAsync(eventId);
            if(info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        [HttpGet]
        public async Task<ActionResult<List<EventInfoDto>>> GetEvents([FromQuery] EventsQueryConditions condition)
        {
            var events = await _clubEventService.GetEventsByConditionAsync(condition);
            if(events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        //[HttpPost("getalleventsofclub")]
        //public async Task<ActionResult<List<EventInfoDto>>> GettAllEventOfClub([FromBody]int clubId)
        //{
        //    var clubs = await _clubEventService.GetAllEventsOfClubAsync(clubId);
        //    if(clubs == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(clubs);
        //}

        //[HttpPost("getalleventsbykeyword")]
        //public async Task<ActionResult<List<EventInfoDto>>> GetAllEventsByKeyword([FromBody]string keyword)
        //{
        //    var events = await _clubEventService.GetAllEventByKeywordAsync(keyword);
        //    if(events == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(events);
        //}

        [Authorize(Roles = "ClubManager")]
        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] EventUpdateDto eventUpdateDto)
        {
            var result = await _clubEventService.UpdateEventAsync(eventId, eventUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var result = await _clubEventService.DeleteEventAsync(eventId);
            return result ? NoContent() : BadRequest();
        }
    }
}
