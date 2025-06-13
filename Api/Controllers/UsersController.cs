using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.UserDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Authorize(Roles = "GeneralUser, ClubManager")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public UsersController(IAuthService authService,
            IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet("myinfo")]
        public async Task<ActionResult<UserInfoDto>> GetMyInfo()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) 
            {
                return Unauthorized();
            }
            var userId = int.Parse(userIdClaim.Value);
            var result = await _userService.GetUserByIdAsync(userId);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetUserByUsername(string username)
        //{
        //    var result = await _userService.GetUserByUsernameAsync(username);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        [HttpPut("update-info")]
        public async Task<IActionResult> UpdateInfo([FromBody] UserUpdateDto userUpdateDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            var userId = int.Parse(userIdClaim.Value);
            var result = await _userService.UpdateUserAsync(userId, userUpdateDto);
            return result ? NoContent() : BadRequest();
        }
    }
}
