using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.AuthDTOs;
using SportGroups.Shared.DTOs.UserDTOs;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public UserController(IAuthService authService,
            IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.AuthAsync(loginDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);
            if(result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await _userService.GetUserByIdAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var result = await _userService.GetUserByUsernameAsync(username);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditInfo(UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateUserAsync(userUpdateDto);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
