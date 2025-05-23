﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.DTOs.MessageDTOs;

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

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateMessage(NewMessageDto newMessageDto)
        {
            var result = await _messageService.CreateMessageAsync(newMessageDto);
            return result ? CreatedAtAction(nameof(MessageController), "Message", new { }, result) : BadRequest();
        }

        [HttpPost("displaymessage")]
        public async Task<ActionResult<MessageInfoDto?>> GetMessage([FromBody]int messageId)
        {
            var message = await _messageService.GetMessageByIdAsync(messageId);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost("messagesofclub")]
        public async Task<ActionResult<List<MessageInfoDto>>> GetAllMessagesOfClub([FromBody]int clubId)
        {
            var messages = await _messageService.GetAllMessagesOfClubAsync(clubId);
            if(messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMessage(MessageUpdateDto messageUpdateDto)
        {
            var result = await _messageService.UpdateMessageAsync(messageUpdateDto);
            return result ? NoContent() : BadRequest();
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMessage([FromBody]int messageId)
        {
            var result = await _messageService.DeleteMessageAsync(messageId);
            return result ? NoContent() : BadRequest();
        }
    }
}
