using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.UserDTOs;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService,
            IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        // 登入
        [HttpPost("login")]
        public async Task<ActionResult<UserInfoDto>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.AuthAsync(loginDto);
            if (result == null)
            {
                return Unauthorized("使用者名稱或密碼輸入錯誤!");
            }
            return Ok(result);
        }

        // 註冊
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result.ResponseMessage);
            }
            
            return Created($"/api/users/myinfo", "註冊成功!請登入!"); 
        }

    }
}
