using AutoMapper;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ArticleDTOs;
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
            CreateMap<NewArticleDto, Article>().ReverseMap();
            CreateMap<Article, ArticleInfoDto>().ReverseMap();
            CreateMap<List<Article>, List<ArticleInfoDto>>().ReverseMap();
        }
    }
}
