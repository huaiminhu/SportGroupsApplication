﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task AttendEvent(int userId, int eventId);
    }
}
