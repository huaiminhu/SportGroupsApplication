using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public Task<bool> AttendEventAsync(EnrollmentDto enrollmentDto)
        {
            throw new NotImplementedException();
        }

        public Task<EnrollmentDto?> GetEnrollmentByIdAsync(Guid userId, int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
