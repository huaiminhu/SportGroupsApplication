using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<bool> CreateMessageAsync(Message message);
        Task<Message?> GetMessageByIdAsync(int messageId);

        // 取得指定社團所有公告訊息
        Task<List<Message>> GetAllMessageOfClubAsync(int clubId);
        Task<bool> UpdateTitleAsync(int messageId, string newTitle);
        Task<bool> UpdateContentAsync(int messageId, string newContent);
        Task<bool> DeleteMessageAsync(int messageId);
    }
}
