using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        // 參加活動
        Task AttendEvent(int userId, int eventId);

        // 取得指定社團所有活動
        Task<List<ClubEvent>> GetAllEventsOfClub(int clubId);
        
        // 取得使用者參與的所有活動
        Task<List<ClubEvent>> GetAllEventsOfUser(int userId);
    }
}
