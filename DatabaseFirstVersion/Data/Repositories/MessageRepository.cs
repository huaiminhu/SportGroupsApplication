using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SportGroups.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {

        private readonly SportGroupsDbContext _context;
        public MessageRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task CreateMessageAsync(ClubMessage message)
        {
            await _context.ClubMessages.AddAsync(message);
        }

        public async Task<ClubMessage?> GetMessageByIdAsync(int messageId)
        {
            return await _context.ClubMessages.FirstOrDefaultAsync(m => m.ClubMessageId == messageId);
        }

        public void DeleteMessage(ClubMessage message)
        {
            _context.ClubMessages.Remove(message);
        }

        public async Task<List<ClubMessage>> GetAllMessagesOfClubAsync(int clubId)
        {
            return await _context.ClubMessages
                .AsNoTracking()
                .Where(m => m.ClubId == clubId)
                .ToListAsync();
        }

        public void UpdateMessage(ClubMessage message)
        {
            _context.ClubMessages.Update(message);
        }
    }
}
