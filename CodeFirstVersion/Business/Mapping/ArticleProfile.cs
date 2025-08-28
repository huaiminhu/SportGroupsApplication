using AutoMapper;
using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.DTOs.MediaDTOs;

namespace SportGroups.Business.Mapping
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            // 對非null值進行更新
            CreateMap<ArticleUpdateDto, Article>()
                .ForMember(dest => dest.Medias, opt => opt.Ignore())
                .ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null));
            CreateMap<NewArticleDto, Article>()
                .ForMember(dest => dest.Medias, opt => opt.Ignore()); // 避免自動轉換 List<IFormFile> -> List<Media>
            CreateMap<Article, ArticleInfoDto>();
            CreateMap<Media, MediaInfoDto>();
        }
    }
}
