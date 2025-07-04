using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Authorize(Roles = "GeneralUser")]
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
        [HttpPost]
        public async Task<IActionResult> JoinClub([FromBody] NewMemberDto newMemberDto)
        {
            var result = await _memberService.JoinClubAsync(newMemberDto);
            if(!result.IsSuccess)
            {
                return BadRequest(result.ResponseMessage);
            }
            
            return Created(result.ResponseMessage, result);
        }

        // 讀取使用者參與的所有社團資訊
        [HttpGet("my-clubs")]
        public async Task<ActionResult<List<ClubInfoDto>>> ClubsOfUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var clubs = await _memberService.GetAllClubsOfUserAsync(userId);
            if (clubs == null)
            {
                return NotFound("找不到任何社團資訊!");
            }
            return Ok(clubs);
        }
    }
}
