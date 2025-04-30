using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.MessageDTOs;
using SportGroups.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateMessageAsync(NewMessageDto newMessageDto)
        {
            var newMessage = _mapper.Map<Message>(newMessageDto);
            return await _unitOfWork.Messages.CreateMessageAsync(newMessage);
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            return await _unitOfWork.Messages.DeleteMessageAsync(messageId);
        }

        public async Task<List<MessageInfoDto>> GetAllMessagesOfClubAsync(int clubId)
        {
            var messages = await _unitOfWork.Messages.GetAllMessagesOfClubAsync(clubId);
            return _mapper.Map<List<MessageInfoDto>>(messages);
        }

        public async Task<MessageInfoDto?> GetMessageByIdAsync(int messageId)
        {
            var message = await _unitOfWork.Messages.GetMessageByIdAsync(messageId);
            return _mapper.Map<MessageInfoDto>(message);
        }

        public async Task<bool> UpdateContentAsync(int messageId, string newContent)
        {
            return await _unitOfWork.Messages.UpdateContentAsync(messageId, newContent);
        }

        public async Task<bool> UpdateTitleAsync(int messageId, string newTitle)
        {
            return await _unitOfWork.Messages.UpdateTitleAsync(messageId, newTitle);
        }
    }
}
