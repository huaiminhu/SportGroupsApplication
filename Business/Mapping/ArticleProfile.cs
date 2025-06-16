using AutoMapper;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.DTOs.MediaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Mapping
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleUpdateDto, Article>()
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<NewArticleDto, Article>()
                .ForMember(dest => dest.Medias, opt => opt.Ignore()); // 避免自動轉換 List<IFormFile> -> List<Media>
            CreateMap<Article, ArticleInfoDto>();
            CreateMap<Media, MediaInfoDto>().ReverseMap();
        }
    }
}
