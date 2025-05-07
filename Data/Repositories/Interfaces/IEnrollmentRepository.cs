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
        // 新增活動報名
        Task AddEnrollmentAsync(int userId, int eventId, string phone, DateTime enrollDate);
        Task<Enrollment?> GetEnrollmentByIdAsync(int userId, int eventId);
    }
}
