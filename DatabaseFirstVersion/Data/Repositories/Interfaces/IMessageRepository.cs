using SportGroups.Data.Entities;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateMessageAsync(ClubMessage message);
        Task<ClubMessage?> GetMessageByIdAsync(int messageId);

        // 取得指定社團所有公告訊息
        Task<List<ClubMessage>> GetAllMessagesOfClubAsync(int clubId);
        void UpdateMessage(ClubMessage message);
        void DeleteMessage(ClubMessage message);
    }
}
