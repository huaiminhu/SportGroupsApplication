using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.Enums;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        //[HttpPost("getallclubsbysport")]
        //public async Task<ActionResult<List<ClubInfoDto>>> GetAllClubsBySport(Sport sport)
        //{
        //    var clubs = await _clubService.GetAllClubsBySportAsync(sport);
        //    if (clubs == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(clubs);
        //}

        //[HttpPost("getallclubsbykeyword")]
        //public async Task<ActionResult<List<ClubInfoDto>>> GetAllClubsByKeyword(string keyword)
        //{
        //    var clubs = await _clubService.GetAllClubsByKeywordAsync(keyword);
        //    if(clubs == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(clubs);
        //}

        [HttpGet("clubs")]
        public async Task<ActionResult<List<ClubInfoDto>>> GetClubs(ClubsQueryConditions condition)
        {
            var clubs = await _clubService.GetClubsByConditionAsync(condition);
            if(clubs == null)
            {
                return NotFound();
            }
            return Ok(clubs);
        }

        [HttpGet("club")]
        public async Task<ActionResult<ClubInfoDto>> GetClubInfo([FromBody]int clubId)
        {
            var club = await _clubService.GetClubInfoAsync(clubId);
            if(club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateClub(NewClubDto newClubDto)
        {
            var result = await _clubService.CreateClubAsync(newClubDto);
            return result ? CreatedAtAction(nameof(ClubController.GetClubInfo), "Club", new {}, result) : BadRequest();
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateClub(ClubUpdateDto newClubUpdateDto)
        {
            var result = await _clubService.UpdateClubAsync(newClubUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteClub([FromBody]int clubId)
        {
            var result = await _clubService.DeleteClubAsync(clubId);
            return result ? NoContent() : BadRequest();
        }
    }
}
