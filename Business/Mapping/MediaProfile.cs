using AutoMapper;
using SportGroups.Shared.DTOs.MediaDTOs;
using SportGroups.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class MediaProfile : Profile
    {
        public MediaProfile()
        {
            CreateMap<NewMediaDto, Media>().ReverseMap();
            //CreateMap<List<Media>, List<MediaInfoDto>>().ReverseMap();
        }
    }
}
