using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ClubEventDTOs;
using SportGroups.Shared.DTOs.EventDTOs;

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

        // 辦活動
        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] NewEventDto newEventDto)
        {
            var result = await _clubEventService.CreateEventAsync(newEventDto);
            if(result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(ClubEventsController.GetEvent), new { eventId = result }, result);
        }

        // 讀取活動資訊
        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventInfoDto>> GetEvent(int eventId)
        {
            var info = await _clubEventService.GetEventInfoAsync(eventId);
            if(info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        // (依條件)查詢活動
        [HttpGet]
        public async Task<ActionResult<List<EventInfoDto>>> SearchEvents([FromQuery] EventsQueryConditions condition)
        {
            var events = await _clubEventService.GetEventsByConditionAsync(condition);
            if(events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        // 更新活動資訊
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] EventUpdateDto eventUpdateDto)
        {
            var result = await _clubEventService.UpdateEventAsync(eventId, eventUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        // 刪除活動
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var result = await _clubEventService.DeleteEventAsync(eventId);
            return result ? NoContent() : BadRequest();
        }
    }
}
