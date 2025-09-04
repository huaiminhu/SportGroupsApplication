using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.MessageDTOs;
using SportGroups.Data.Entities;

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

        public async Task<int?> CreateMessageAsync(NewMessageDto newMessageDto)
        {
            var newMessage = _mapper.Map<ClubMessage>(newMessageDto);
            newMessage.PostedDate = DateTime.Now;
            await _unitOfWork.Messages.CreateMessageAsync(newMessage);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0 ? newMessage.ClubMessageId : null;
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            var existing = await _unitOfWork.Messages.GetMessageByIdAsync(messageId);
            if(existing == null)
            {
                return false;
            }
            _unitOfWork.Messages.DeleteMessage(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
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

        public async Task<bool> UpdateMessageAsync(int messageId, MessageUpdateDto messageUpdateDto)
        {
            var existing = await _unitOfWork.Messages.GetMessageByIdAsync(messageId);
            if(existing == null)
            {
                return false;
            }
            _mapper.Map(messageUpdateDto, existing);
            _unitOfWork.Messages.UpdateMessage(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
