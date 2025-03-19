using DataAccess.Entities;
using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task CreateEvent(ClubEvent evt);
        Task<List<ClubEvent>> GetAllEventsOfClub(int clubId);
        Task<List<ClubEvent>> GetAllEventsOfUser(int userId);
        Task<List<ClubEvent>> GetAllEventsBySport(Sport sport);
        Task UpdateEvent(ClubEvent evt);
        Task DeleteEvent(int eventId);
    }
}
