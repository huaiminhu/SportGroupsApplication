using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.EnrollmentDTOs;
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
        private readonly IMapper _mapper;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<bool> AttendEventAsync(EnrollmentDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            return await _enrollmentRepository.AddEnrollmentAsync(enrollment);
        }

        public Task<EnrollmentDto?> GetEnrollmentByIdAsync(int userId, int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
