﻿using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services.IServices
{
    public interface IEnrollmentService
    {
        // 參加社團活動
        Task<bool> AttendEventAsync(EnrollmentDto enrollmentDto);
        Task<EnrollmentDto?> GetEnrollmentByIdAsync(Guid userId, int eventId);
    }
}
