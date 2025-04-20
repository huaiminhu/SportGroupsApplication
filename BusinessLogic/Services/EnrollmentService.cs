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

        public async Task<bool> AttendEventAsync(NewEnrollmentDto newEnrollmentDto)
        {
            var uId = newEnrollmentDto.UserId;
            var eId = newEnrollmentDto.ClubEventId;
            var phone = newEnrollmentDto.Phone;
            var enrollDate = DateTime.Now;
            return await _enrollmentRepository.AddEnrollmentAsync(uId, eId, phone, enrollDate);
        }

        public async Task<EnrollmentInfoDto?> GetEnrollmentByIdAsync(int userId, int eventId)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(userId, eventId);
            return _mapper.Map<EnrollmentInfoDto>(enrollment);
        }
    }
}
