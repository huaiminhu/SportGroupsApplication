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
        Task AttendEventAsync(int userId, int eventId);
    }
}
