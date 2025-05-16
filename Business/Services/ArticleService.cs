using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportGroups.Data.Repositories;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;

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

        //public async Task<bool> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        //{
        //    var existing = await _unitOfWork.Articles.GetArticleByIdAsync(articleUpdateDto.ArticleId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    _mapper.Map(articleUpdateDto, existing);
        //    existing.EditDate = DateTime.Now;
        //    _unitOfWork.Articles.UpdateArticle(existing);
        //    return await _unitOfWork.SaveChangesAsync() > 0;
        //}

        public async Task<bool> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var existing = await _unitOfWork.Articles.GetArticleByIdAsync(articleUpdateDto.ArticleId);
            if (existing == null)
            {
                return false;
            }

            // 刪除未保留的媒體
            if (articleUpdateDto.StayMediaIds != null)
            {
                var toRemove = existing.Medias
                    .Where(m => !articleUpdateDto.StayMediaIds.Contains(m.ArticleMediaId))
                    .ToList();

                foreach (var media in toRemove)
                {
                    await _mediaService.DeleteMediaAsync(media.FileUrl);
                    _unitOfWork.Medias.DeleteMedia(media);
                }
            }

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
            existing.EditDate = nowTime;
            _mapper.Map(articleUpdateDto, existing);
            _unitOfWork.Articles.UpdateArticle(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }


        //public async Task<bool> ChangeContentAsync(int articleId, string newContent)
        //{
        //    return await _unitOfWork.Articles.UpdateContentAsync(articleId, newContent);
        //}

        //public async Task<bool> ChangeDateAsync(int articleId, DateTime latestEdit)
        //{
        //    return await _unitOfWork.Articles.UpdateDateAsync(articleId, latestEdit);
        //}

        //public async Task<bool> ChangeTitleAsync(int articleId, string newTitle)
        //{
        //    return await _unitOfWork.Articles.UpdateTitleAsync(articleId, newTitle);
        //}

        public async Task<bool> CreateArticleAsync(NewArticleDto newArticleDto, List<IFormFile> medias)
        {
            var nowTime = DateTime.Now;
            var newArticle = _mapper.Map<Article>(newArticleDto);
            newArticle.PostDate = nowTime;
            newArticle.EditDate = nowTime;

            foreach (var file in medias)
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

            await _unitOfWork.Articles.CreateArticleAsync(newArticle);
            return await _unitOfWork.SaveChangesAsync() > 0;
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

        public async Task<List<ArticleInfoDto>> GetAllArticlesByKeywordAsync(string keyword)
        {
            var articles = await _unitOfWork.Articles.GetAllArticlesByKeywordAsync(keyword);
            return _mapper.Map<List<ArticleInfoDto>>(articles);
        }

        public async Task<List<ArticleInfoDto>> GetAllArticlesBySportAsync(Sport sport)
        {
            var articles = await _unitOfWork.Articles.GetAllArticlesBySportAsync(sport);
            return _mapper.Map<List<ArticleInfoDto>>(articles);
        }
    }
}
