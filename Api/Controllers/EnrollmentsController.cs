using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.EnrollmentDTOs;

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

        [HttpPost("attend")]
        public async Task<IActionResult> AttendEvent([FromBody] NewEnrollmentDto newEnrollmentDto)
        {
            var result = await _enrollmentService.AttendEventAsync(newEnrollmentDto);
            return result ? CreatedAtAction(nameof(EnrollmentsController.GetEnrollment), "Enrollment", new { }, result) : BadRequest();
        }

        [HttpGet("event/{eventId}/user/{userId}")]
        public async Task<ActionResult<EnrollmentInfoDto?>> GetEnrollment(int eventId, int userId)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(userId, eventId);
            if (enrollment == null)
            {
                return BadRequest();
            }
            return Ok(enrollment);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<EnrollmentInfoDto>>> EnrollmentsOfUser(int userId)
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsOfUserAsync(userId);
            if (enrollments == null)
            {
                return NotFound();
            }
            return Ok(enrollments);
        }
    }
}
