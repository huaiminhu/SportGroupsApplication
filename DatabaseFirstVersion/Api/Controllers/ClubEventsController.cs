using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.DTOs.ClubEventDTOs;
using SportGroups.Shared.DTOs.EventDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubEventsController : ControllerBase
    {
        private readonly IClubEventService _clubEventService;
        private readonly IClubMemberService _memberService;
        public ClubEventsController(IClubEventService clubEventService, IClubMemberService memberService)
        {
            _clubEventService = clubEventService;
            _memberService = memberService;

        }

        // 辦活動
        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] NewEventDto newEventDto)
        {
            // 驗證辦理活動的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var authResult = await _memberService.GetMemberAsync(userId, newEventDto.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 辦活動
            var result = await _clubEventService.CreateEventAsync(newEventDto);
            if(result == null)
            {
                return BadRequest("辦理失敗!");
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
                return NotFound("找不到任何活動!");
            }
            return Ok(info);
        }

        // (依條件)查詢活動
        [HttpGet]
        public async Task<ActionResult<List<EventInfoDto>>> SearchEvents([FromQuery] EventsQueryConditions condition)
        {
            var events = await _clubEventService.SearchEventsAsync(condition);
            if(events == null)
            {
                return NotFound("找不到任何活動!");
            }
            return Ok(events);
        }

        // 更新活動資訊
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] EventUpdateDto eventUpdateDto)
        {
            // 驗證更新活動的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var getEvent = await _clubEventService.GetEventInfoAsync(eventId);
            if (getEvent == null)
            {
                return BadRequest("活動不存在!");
            }
            var authResult = await _memberService.GetMemberAsync(userId, getEvent.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 更新活動資訊
            var result = await _clubEventService.UpdateEventAsync(eventId, eventUpdateDto);
            return result ? NoContent() : BadRequest("更新失敗!");
        }

        // 刪除活動
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            // 驗證刪除活動的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            var userId = int.Parse(userIdClaim.Value);
            var getEvent = await _clubEventService.GetEventInfoAsync(eventId);
            if (getEvent == null)
            {
                return BadRequest("活動不存在!");
            }
            var authResult = await _memberService.GetMemberAsync(userId, getEvent.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 刪除活動
            var result = await _clubEventService.DeleteEventAsync(eventId);
            return result ? NoContent() : BadRequest("刪除失敗!");
        }
    }
}
