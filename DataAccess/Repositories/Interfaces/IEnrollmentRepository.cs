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
        Task<bool> AddEnrollmentAsync(Enrollment enrollment);
        Task<Enrollment?> GetEnrollmentInfo(Guid userId, int eventId);
    }
}
