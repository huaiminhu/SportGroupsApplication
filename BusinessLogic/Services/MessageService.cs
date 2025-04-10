using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task<bool> CreateMessageAsync(MessageDto messageDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            return await _messageRepository.DeleteMessageAsync(messageId);
        }

        public Task<List<MessageDto>> GetAllMessageOfClubAsync(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto?> GetMessageByIdAsync(int messageId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateContentAsync(int messageId, string newContent)
        {
            return await _messageRepository.UpdateContentAsync(messageId, newContent);
        }

        public async Task<bool> UpdateTitleAsync(int messageId, string newTitle)
        {
            return await _messageRepository.UpdateTitleAsync(messageId, newTitle);
        }
    }
}
