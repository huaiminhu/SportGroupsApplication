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
        Task CreateMessageAsync(Message message);
        Task<List<Message>> GetAllMessageOfClubAsync(string clubId);
        Task UpdateMessageAsync(Message message);
        Task DeleteMessageAsync(int messageId);
    }
}
