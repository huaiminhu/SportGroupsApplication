﻿using AutoMapper;
using SportGroups.Shared.Entities;
using SportGroups.Shared.DTOs.ClubDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<NewClubDto, Club>().ReverseMap();
            CreateMap<Club, ClubInfoDto>().ReverseMap();
            CreateMap<List<Club>, List<ClubInfoDto>>().ReverseMap();
        }
    }
}
