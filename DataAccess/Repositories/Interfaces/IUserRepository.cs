using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        User GetUser(string username, string password);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
