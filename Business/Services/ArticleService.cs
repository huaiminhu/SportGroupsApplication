using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.Enums;

namespace SportGroups.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;
        public ArticleService(IUnitOfWork unitOfWork, 
            IMapper mapper,
            IMediaService mediaService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediaService = mediaService;

        }

        public async Task<bool> UpdateArticleAsync(int articleId, ArticleUpdateDto articleUpdateDto)
        {
            var existing = await _unitOfWork.Articles.GetArticleByIdAsync(articleId);
            if (existing == null)
            {
                return false;
            }

            // 用從前端接收的DTO覆蓋原來的Entity
            _mapper.Map(articleUpdateDto, existing);

            // 刪除未保留的媒體
            if (articleUpdateDto.StayMediaIds != null)
            {
                var toRemove = existing.Medias
                    .Where(m => !articleUpdateDto.StayMediaIds.Contains(m.MediaId))
                    .ToList();

                foreach (var media in toRemove)
                {
                    // 只有圖片或影片需要刪除實體檔案
                    if (media.MediaType != MediaType.YouTube)
                        await _mediaService.DeleteMediaAsync(media.FileUrl);
                    _unitOfWork.Medias.DeleteMedia(media);
                }
            }

            // 定義新增媒體時間
            var nowTime = DateTime.Now;

            // 新增新的媒體檔案
            if (articleUpdateDto.Medias != null)
            {
                foreach (var file in articleUpdateDto.Medias)
                {
                    var filePath = await _mediaService.SaveMediaAsync(file);
                    existing.Medias.Add(new Media
                    {
                        FileName = file.FileName,
                        MediaType = file.ContentType.StartsWith("video") ? MediaType.Video : MediaType.Image,
                        FileUrl = filePath,
                        AddedDate = nowTime
                    });
                }
            }

            // 新增 YouTube 連結媒體
            if (articleUpdateDto.YouTubeUrls != null)
            {
                foreach (var url in articleUpdateDto.YouTubeUrls)
                {
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        // 儲存為 MediaType = YouTube，不需處理實體檔案
                        existing.Medias.Add(new Media
                        {
                            FileName = "YouTube影片", 
                            MediaType = MediaType.YouTube,
                            FileUrl = url, 
                            AddedDate = nowTime
                        });
                    }
                }
            }

            // 定義文章更新時間為現在
            existing.EditDate = nowTime;

            // 使用UnitOfWork管理Article Repository更新文章
            _unitOfWork.Articles.UpdateArticle(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int?> CreateArticleAsync(NewArticleDto newArticleDto)
        {
            // 定義文章各欄位(從前端傳來)
            var nowTime = DateTime.Now;
            var newArticle = _mapper.Map<Article>(newArticleDto);
            newArticle.PostDate = nowTime;
            newArticle.EditDate = nowTime;

            // 新增新的媒體檔案
            if (newArticleDto.Medias != null)
            {
                foreach (var file in newArticleDto.Medias)
                {
                    var filePath = await _mediaService.SaveMediaAsync(file);
                    newArticle.Medias.Add(new Media
                    {
                        FileName = file.FileName,
                        MediaType = file.ContentType.StartsWith("video") ? MediaType.Video : MediaType.Image,
                        FileUrl = filePath,
                        AddedDate = nowTime
                    });
                }
            }

            // 新增 YouTube 連結媒體
            if (newArticleDto.YouTubeUrls != null)
            {
                foreach (var url in newArticleDto.YouTubeUrls)
                {
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        // 儲存為 MediaType = YouTube，不需處理實體檔案
                        newArticle.Medias.Add(new Media
                        {
                            FileName = "YouTube影片",
                            MediaType = MediaType.YouTube,
                            FileUrl = url,
                            AddedDate = nowTime
                        });
                    }
                }
            }

            // UnitOfWork管理Article Repository
            await _unitOfWork.Articles.CreateArticleAsync(newArticle);
            var result = await _unitOfWork.SaveChangesAsync();

            // 若新增成功回傳ID, 失敗回傳null
            return result > 0 ? newArticle.ArticleId : null;
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            var existing = await _unitOfWork.Articles.GetArticleByIdAsync(articleId);
            if (existing == null)
            {
                return false;
            }
            _unitOfWork.Articles.DeleteArticle(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<ArticleInfoDto?> GetArticleByIdAsync(int articleId)
        {
            var article = await _unitOfWork.Articles.GetArticleByIdAsync(articleId);
            return _mapper.Map<ArticleInfoDto?>(article);
        }

        public async Task<List<ArticleInfoDto>> SearchArticlesAsync(ArticlesQueryConditions condition)
        {
            var articles = await _unitOfWork.Articles.GetArticlesByConditionAsync(condition);
            return _mapper.Map<List<ArticleInfoDto>>(articles);
        }
    }
}
