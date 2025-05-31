using SportGroups.Shared.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IMessageService
    {
        Task<bool> CreateMessageAsync(NewMessageDto newMessageDto);
        Task<MessageInfoDto?> GetMessageByIdAsync(int messageId);
        
        // 取得指定社團所有訊息
        Task<List<MessageInfoDto>> GetAllMessagesOfClubAsync(int clubId);
        Task<bool> UpdateMessageAsync(int messageId, MessageUpdateDto messageUpdateDto);
        //Task<bool> UpdateTitleAsync(int messageId, string newTitle);
        //Task<bool> UpdateContentAsync(int messageId, string newContent);
        Task<bool> DeleteMessageAsync(int messageId);
    }
}
