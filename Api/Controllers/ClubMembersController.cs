using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ClubDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubMembersController : ControllerBase
    {
        private readonly IClubMemberService _memberService;
        public ClubMembersController(IClubMemberService memberService)
        {
            _memberService = memberService;
        }

        // 加入社團
        [Authorize(Roles = "GeneralUser")]
        [HttpPost]
        public async Task<IActionResult> JoinClub([FromBody] int clubId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);

            // 加入社團
            var result = await _memberService.JoinClubAsync(userId, clubId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ResponseMessage);
            }

            return Created(result.ResponseMessage, result);
        }

        // 讀取使用者參與的所有社團資訊
        [Authorize]
        [HttpGet("my-clubs")]
        public async Task<ActionResult<List<ClubInfoDto>>> GetAllClubsOfUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            
            // 讀取使用者社團資訊
            var clubs = await _memberService.GetAllClubsOfUserAsync(userId);
            if (clubs == null)
            {
                return NotFound("找不到任何社團資訊!");
            }
            return Ok(clubs);
        }

        // 退出社團
        [Authorize(Roles = "GeneralUser")]
        [HttpDelete("{clubId}")]
        public async Task<IActionResult> QuitClub(int clubId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            
            // 退出社團
            var result = await _memberService.QuitClubAsync(
                userId, clubId);
            return result.IsSuccess ? NoContent() : BadRequest(result.ResponseMessage);
        }
    }
}
