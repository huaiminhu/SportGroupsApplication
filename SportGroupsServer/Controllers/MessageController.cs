using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
    }
}
