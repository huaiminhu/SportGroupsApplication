using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IMessageService
    {
        Task<bool> CreateMessageAsync(MessageDto messageDto);
        Task<MessageDto?> GetMessageByIdAsync(int messageId);
        
        // 取得指定社團所有訊息
        Task<List<MessageDto>> GetAllMessagesOfClubAsync(int clubId);
        Task<bool> UpdateTitleAsync(int messageId, string newTitle);
        Task<bool> UpdateContentAsync(int messageId, string newContent);
        Task<bool> DeleteMessageAsync(int messageId);
    }
}
