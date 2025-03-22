using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
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

        public Task CreateMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMessageAsync(int messageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetAllMessageOfClubAsync(string clubId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
