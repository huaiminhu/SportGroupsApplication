using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportGroups.Business.Services;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ClubDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;
        private readonly IClubMemberService _memberService;
        public ClubsController(IClubService clubService, IClubMemberService memberService)
        {
            _clubService = clubService;
            _memberService = memberService;

        }

        // (依條件)查詢社團
        [HttpGet]
        public async Task<ActionResult<List<ClubInfoDto>>> GetClubs([FromQuery] ClubsQueryConditions condition)
        {
            var clubs = await _clubService.GetClubsByConditionAsync(condition);
            if(clubs == null)
            {
                return NotFound("找不到任何社團!");
            }
            return Ok(clubs);
        }

        // 讀取社團資訊
        [HttpGet("{clubId}")]
        public async Task<ActionResult<ClubInfoDto>> GetClub(int clubId)
        {
            var club = await _clubService.GetClubByIdAsync(clubId);
            if(club == null)
            {
                return NotFound("找不到任何社團!");
            }
            return Ok(club);
        }

        // 創立社團
        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateClub([FromBody] NewClubDto newClubDto)
        {
            // 讀取使用者ID
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            
            // 新增社團
            var result = await _clubService.CreateClubAsync(userId, newClubDto);
            if(result == null)
            {
                return BadRequest("新增失敗!");
            }
            return CreatedAtAction(nameof(GetClub), new {clubId = result}, result);
        }

        // 更新社團資訊
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{clubId}")]
        public async Task<IActionResult> UpdateClub(int clubId, [FromBody] ClubUpdateDto newClubUpdateDto)
        {
            // 驗證更新社團資訊的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var authResult = await _memberService.GetMemberAsync(userId, clubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 更新社團資訊
            var result = await _clubService.UpdateClubAsync(clubId, newClubUpdateDto);
            return result ? NoContent() : BadRequest("更新失敗!");
        }

        // 刪除社團
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{clubId}")]
        public async Task<IActionResult> DeleteClub(int clubId)
        {
            // 驗證刪除社團的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var authResult = await _memberService.GetMemberAsync(userId, clubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 刪除社團
            var result = await _clubService.DeleteClubAsync(clubId);
            return result ? NoContent() : BadRequest("刪除失敗!");
        }
    }
}
