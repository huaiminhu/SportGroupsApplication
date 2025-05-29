using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;

namespace SportGroups.Api.Controllers
{
    [Authorize(Roles = "GeneralUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClubMemberController : ControllerBase
    {
        private readonly IClubMemberService _memberService;
        public ClubMemberController(IClubMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("new-member")]
        public async Task<IActionResult> JoinClub([FromBody] NewMemberDto newMemberDto)
        {
            var result = await _memberService.JoinClubAsync(newMemberDto);
            return result ? Created(string.Empty, result) : BadRequest(result);
        }

        [HttpGet("user/{userId}/clubs")]
        public async Task<ActionResult<List<ClubInfoDto>>> ClubsOfUser([FromQuery] int userId)
        {
            var clubs = await _memberService.GetAllClubsOfUserAsync(userId);
            if (clubs == null)
            {
                return NotFound();
            }
            return Ok(clubs);
        }
    }
}
