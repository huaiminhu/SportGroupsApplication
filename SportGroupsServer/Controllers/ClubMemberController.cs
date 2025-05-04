using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubMemberController : ControllerBase
    {
        private readonly IClubMemberService _memberService;
        public ClubMemberController(IClubMemberService memberService)
        {
            _memberService = memberService;
        }
    }
}
