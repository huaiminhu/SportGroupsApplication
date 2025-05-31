using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.MessageDTOs;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] NewMessageDto newMessageDto)
        {
            var result = await _messageService.CreateMessageAsync(newMessageDto);
            return result ? CreatedAtAction(nameof(MessagesController), "Message", new { }, result) : BadRequest();
        }

        [HttpGet("{messageId}")]
        public async Task<ActionResult<MessageInfoDto?>> GetMessage(int messageId)
        {
            var message = await _messageService.GetMessageByIdAsync(messageId);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpGet("club/{clubId}")]
        public async Task<ActionResult<List<MessageInfoDto>>> GetAllMessagesOfClub(int clubId)
        {
            var messages = await _messageService.GetAllMessagesOfClubAsync(clubId);
            if(messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }

        [Authorize(Roles = "ClubManager")]
        [HttpPut("{messageId}")]
        public async Task<IActionResult> UpdateMessage(int messageId, [FromBody] MessageUpdateDto messageUpdateDto)
        {
            var result = await _messageService.UpdateMessageAsync(messageId, messageUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{meassageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            var result = await _messageService.DeleteMessageAsync(messageId);
            return result ? NoContent() : BadRequest();
        }
    }
}
