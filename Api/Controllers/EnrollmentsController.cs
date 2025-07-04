using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.EnrollmentDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Authorize(Roles = "GeneralUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // 參加活動
        [HttpPost]
        public async Task<IActionResult> AttendEvent([FromBody] NewEnrollmentDto newEnrollmentDto)
        {
            var result = await _enrollmentService.AttendEventAsync(newEnrollmentDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ResponseMessage);
            }

            return Created(result.ResponseMessage, result);
        }

        // 讀取報名資訊
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<EnrollmentInfoDto?>> GetEnrollment(int eventId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(userId, eventId);
            if (enrollment == null)
            {
                return NotFound("找不到任何報名資訊!");
            }
            return Ok(enrollment);
        }

        // 讀取使用者所有報名資訊
        [HttpGet("my-enrollments")]
        public async Task<ActionResult<List<EnrollmentInfoDto>>> EnrollmentsOfUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var enrollments = await _enrollmentService.GetAllEnrollmentsOfUserAsync(userId);
            if (enrollments == null)
            {
                return NotFound("找不到任何報名資訊!");
            }
            return Ok(enrollments);
        }
    }
}
