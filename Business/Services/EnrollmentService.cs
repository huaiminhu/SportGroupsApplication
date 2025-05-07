using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.EnrollmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportGroups.Data.Repositories;

namespace SportGroups.Business.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AttendEventAsync(NewEnrollmentDto newEnrollmentDto)
        {
            var uId = newEnrollmentDto.UserId;
            var eId = newEnrollmentDto.ClubEventId;
            var phone = newEnrollmentDto.Phone;
            var enrollDate = DateTime.Now;
            await _unitOfWork.Enrollments.AddEnrollmentAsync(uId, eId, phone, enrollDate);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<EnrollmentInfoDto?> GetEnrollmentByIdAsync(int userId, int eventId)
        {
            var enrollment = await _unitOfWork.Enrollments.GetEnrollmentByIdAsync(userId, eventId);
            return _mapper.Map<EnrollmentInfoDto>(enrollment);
        }
    }
}
