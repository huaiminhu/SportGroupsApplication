using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportGroups.Business.Services;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.MessageDTOs;
using System.Security.Claims;

namespace SportGroups.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IClubMemberService _memberService;
        public MessagesController(IMessageService messageService, 
            IClubMemberService memberService)
        {
            _messageService = messageService;
            _memberService = memberService;
        }

        // 新增社團訊息
        [Authorize(Roles = "ClubManager")]
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] NewMessageDto newMessageDto)
        {
            // 驗證新增社團的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var authResult = await _memberService.GetMemberAsync(userId, newMessageDto.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 新增社團訊息
            var result = await _messageService.CreateMessageAsync(newMessageDto);
            if(result == null)
            {
                return BadRequest("新增失敗!");
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
                return NotFound("沒有任何訊息!");
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
                return NotFound("沒有任何訊息!");
            }
            return Ok(messages);
        }

        // 更新社團訊息
        [Authorize(Roles = "ClubManager")]
        [HttpPut("{messageId}")]
        public async Task<IActionResult> UpdateMessage(int messageId, [FromBody] MessageUpdateDto messageUpdateDto)
        {
            // 驗證更新訊息的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var getMessage = await _messageService.GetMessageByIdAsync(messageId);
            if (getMessage == null)
            {
                return BadRequest("訊息不存在!");
            }
            var authResult = await _memberService.GetMemberAsync(userId, getMessage.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 更新社團訊息
            var result = await _messageService.UpdateMessageAsync(messageId, messageUpdateDto);
            return result ? NoContent() : BadRequest("更新失敗!");
        }

        // 刪除社團訊息
        [Authorize(Roles = "ClubManager")]
        [HttpDelete("{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            // 驗證刪除訊息的社團管理員是否隸屬該社團
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("您沒有權限!");
            }
            var userId = int.Parse(userIdClaim.Value);
            var getMessage = await _messageService.GetMessageByIdAsync(messageId);
            if (getMessage == null)
            {
                return BadRequest("訊息不存在!");
            }
            var authResult = await _memberService.GetMemberAsync(userId, getMessage.ClubId);
            if (!authResult.IsSuccess)
            {
                return BadRequest(authResult.ResponseMessage);
            }

            // 刪除社團訊息
            var result = await _messageService.DeleteMessageAsync(messageId);
            return result ? NoContent() : BadRequest("刪除失敗!");
        }
    }
}
