using Microsoft.AspNetCore.Authorization;
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

        // 新增社團訊息
        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] NewMessageDto newMessageDto)
        {
            var result = await _messageService.CreateMessageAsync(newMessageDto);
            if(result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(MessagesController.GetMessage), new { messageId = result }, result);
        }

        // 讀取社團訊息
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

        // 讀取社團所有訊息
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

        // 更新社團訊息
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{messageId}")]
        public async Task<IActionResult> UpdateMessage(int messageId, [FromBody] MessageUpdateDto messageUpdateDto)
        {
            var result = await _messageService.UpdateMessageAsync(messageId, messageUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        // 刪除社團訊息
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            var result = await _messageService.DeleteMessageAsync(messageId);
            return result ? NoContent() : BadRequest();
        }
    }
}
