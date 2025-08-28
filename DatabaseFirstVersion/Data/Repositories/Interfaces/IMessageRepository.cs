using SportGroups.Data.Entities;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateMessageAsync(Message message);
        Task<Message?> GetMessageByIdAsync(int messageId);

        // 取得指定社團所有公告訊息
        Task<List<Message>> GetAllMessagesOfClubAsync(int clubId);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
    }
}
