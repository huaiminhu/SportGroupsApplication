using AutoMapper;
using SportGroups.Shared.DTOs.MediaDTOs;
using SportGroups.Data.Entities;

namespace SportGroups.Business.Mapping
{
    public class MediaProfile : Profile
    {
        public MediaProfile()
        {
            CreateMap<NewMediaDto, Media>();
        }
    }
}
