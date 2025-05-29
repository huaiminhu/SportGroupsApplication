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
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("attend")]
        public async Task<IActionResult> AttendEvent(NewEnrollmentDto newEnrollmentDto)
        {
            var result = await _enrollmentService.AttendEventAsync(newEnrollmentDto);
            return result ? CreatedAtAction(nameof(EnrollmentController.GetEnrollment), "Enrollment", new { }, result) : BadRequest();
        }

        [HttpGet("clubevent/{eventId}/user/{userId}/enrollment")]
        public async Task<ActionResult<EnrollmentInfoDto?>> GetEnrollment([FromQuery] int eventId, int userId)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(userId, eventId);
            if (enrollment == null)
            {
                return BadRequest();
            }
            return Ok(enrollment);
        }

        [HttpGet("user/{userId}/Enrollments")]
        public async Task<ActionResult<List<EnrollmentInfoDto>>> EnrollmentsOfUser([FromQuery] int userId)
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
