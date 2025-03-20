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

        public Task CreateMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMessage(int messageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetAllMessageOfClub(string clubId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
