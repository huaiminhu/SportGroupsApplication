using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        // 參加活動
        Task<bool> AttendEventAsync(int userId, int eventId);
        Task<Enrollment?> GetEnrollmentInfo(int userId, int eventId);
    }
}
