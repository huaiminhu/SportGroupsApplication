using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        // (依條件)查詢社團
        [HttpGet]
        public async Task<ActionResult<List<ClubInfoDto>>> GetClubs([FromQuery] ClubsQueryConditions condition)
        {
            var clubs = await _clubService.GetClubsByConditionAsync(condition);
            if(clubs == null)
            {
                return NotFound();
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
                return NotFound();
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
                return Unauthorized();
            }
            var userId = int.Parse(userIdClaim.Value);
            
            // 新增社團
            var result = await _clubService.CreateClubAsync(userId, newClubDto);
            if(result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetClub), new {clubId = result}, result);
        }

        // 更新社團資訊
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{clubId}")]
        public async Task<IActionResult> UpdateClub(int clubId, [FromBody] ClubUpdateDto newClubUpdateDto)
        {
            var result = await _clubService.UpdateClubAsync(clubId, newClubUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        // 刪除社團
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{clubId}")]
        public async Task<IActionResult> DeleteClub(int clubId)
        {
            var result = await _clubService.DeleteClubAsync(clubId);
            return result ? NoContent() : BadRequest();
        }
    }
}
