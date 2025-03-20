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

        // 取得指定運動項目類別的所有活動
        Task<List<ClubEvent>> GetAllEventsBySport(Sport sport);
        Task UpdateEvent(ClubEvent evt);
        Task DeleteEvent(int eventId);
    }
}
