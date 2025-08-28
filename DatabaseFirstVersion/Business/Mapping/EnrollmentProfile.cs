using AutoMapper;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.EnrollmentDTOs;

namespace SportGroups.Business.Mapping
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentInfoDto>();
        }
    }
}
