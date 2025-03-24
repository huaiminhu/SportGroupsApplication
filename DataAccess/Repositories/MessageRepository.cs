using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {

        private readonly SportGroupsDbContext _context;
        public MessageRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            var existing = await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == messageId);
            if (existing == null)
            {
                return false;
            }
            _context.Messages.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Message>> GetAllMessageOfClubAsync(int clubId)
        {
            return await _context.Messages.Include(m => m.ClubId == clubId).ToListAsync();
        }

        public async Task<bool> UpdateTitleAsync(int messageId, string newTitle)
        {
            var existing = await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == messageId);
            if (existing == null)
            {
                return false;
            }
            existing.Title = newTitle;
            _context.Entry(existing).Property(m => m.Title).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateContentAsync(int messageId, string newContent)
        {
            var existing = await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == messageId);
            if (existing == null)
            {
                return false;
            }
            existing.MessageContent = newContent;
            _context.Entry(existing).Property(m => m.MessageContent).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
