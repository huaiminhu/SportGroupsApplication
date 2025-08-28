using SportGroups.Shared.DTOs.MessageDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IMessageService
    {
        Task<int?> CreateMessageAsync(NewMessageDto newMessageDto);
        Task<MessageInfoDto?> GetMessageByIdAsync(int messageId);
        
        // 取得指定社團所有訊息
        Task<List<MessageInfoDto>> GetAllMessagesOfClubAsync(int clubId);
        Task<bool> UpdateMessageAsync(int messageId, MessageUpdateDto messageUpdateDto);
        Task<bool> DeleteMessageAsync(int messageId);
    }
}
