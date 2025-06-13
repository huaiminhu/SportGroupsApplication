using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _context.Messages.Where(m => m.ClubId == clubId).ToListAsync();
        }

        public void UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
        }
        //public async Task<bool> UpdateTitleAsync(int messageId, string newTitle)
        //{
        //    var existing = await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == messageId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    existing.Title = newTitle;
        //    _context.Entry(existing).Property(m => m.Title).IsModified = true;
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> UpdateContentAsync(int messageId, string newContent)
        //{
        //    var existing = await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == messageId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    existing.MessageContent = newContent;
        //    _context.Entry(existing).Property(m => m.MessageContent).IsModified = true;
        //    return await _context.SaveChangesAsync() > 0;
        //}
    }
}
