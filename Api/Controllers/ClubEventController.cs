using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubEventController : ControllerBase
    {
        private readonly IClubEventService _clubEventService;
        public ClubEventController(IClubEventService clubEventService)
        {
            _clubEventService = clubEventService;
        }
    }
}
