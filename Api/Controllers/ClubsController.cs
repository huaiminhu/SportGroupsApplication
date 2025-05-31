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
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubsController(IClubService clubService)
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

        [HttpGet("{clubId}")]
        public async Task<ActionResult<ClubInfoDto>> GetClubInfo(int clubId)
        {
            var club = await _clubService.GetClubInfoAsync(clubId);
            if(club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateClub([FromBody] NewClubDto newClubDto)
        {
            var result = await _clubService.CreateClubAsync(newClubDto);
            return result ? CreatedAtAction(nameof(ClubsController.GetClubInfo), "Club", new {}, result) : BadRequest();
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPut("{clubId}")]
        public async Task<IActionResult> UpdateClub(int clubId, [FromBody] ClubUpdateDto newClubUpdateDto)
        {
            var result = await _clubService.UpdateClubAsync(clubId, newClubUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{clubId}")]
        public async Task<IActionResult> DeleteClub(int clubId)
        {
            var result = await _clubService.DeleteClubAsync(clubId);
            return result ? NoContent() : BadRequest();
        }
    }
}
