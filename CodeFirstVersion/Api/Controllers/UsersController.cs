using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.UserDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // 讀取使用者資訊
        [HttpGet]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var result = await _userService.GetUserInfoAsync(userId);
            return Ok(result);
        }

        // 變更密碼
        [HttpPatch("Password")]
        public async Task<IActionResult> ChangePassword([FromBody] string password)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var result = await _userService.ChangePasswordAsync(userId, password);
            return result ? NoContent() : BadRequest("更新失敗!");
        }

        // 變更使用者暱稱
        [HttpPatch("NickName")]
        public async Task<IActionResult> UpdateNickName([FromBody] string nickname)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var result = await _userService.ChangeNickNameAsync(userId, nickname);
            return result ? NoContent() : BadRequest("更新失敗!");
        }
    }
}
