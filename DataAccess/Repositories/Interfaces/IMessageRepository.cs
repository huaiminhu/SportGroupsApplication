using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateMessage(Message message);
        Task<List<Message>> GetAllMessageOfClub(string clubId);
        Task UpdateMessage(Message message);
        Task DeleteMessage(int messageId);
    }
}
