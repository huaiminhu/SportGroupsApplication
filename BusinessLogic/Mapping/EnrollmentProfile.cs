using AutoMapper;
using SportGroups.Shared.Entities;
using SportGroups.Shared.DTOs.EnrollmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<EnrollmentDto, Enrollment>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
        }
    }
}
