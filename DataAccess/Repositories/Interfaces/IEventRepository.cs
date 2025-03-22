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
        Task CreateEventAsync(ClubEvent evt);

        // 取得指定運動項目類別的所有活動
        Task<List<ClubEvent>> GetAllEventsBySportAsync(Sport sport);
        Task UpdateEventAsync(ClubEvent evt);
        Task DeleteEventAsync(int eventId);
    }
}
