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

        public async Task CreateMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message?> GetMessageByIdAsync(int messageId)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == messageId);
        }

        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<List<Message>> GetAllMessagesOfClubAsync(int clubId)
        {
            return await _context.Messages
                .AsNoTracking()
                .Where(m => m.ClubId == clubId)
                .ToListAsync();
        }

        public void UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
        }
    }
}
