using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ArticleDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<bool> ChangeContentAsync(int articleId, string newContent)
        {
            return await _articleRepository.UpdateContentAsync(articleId, newContent);
        }

        public async Task<bool> ChangeDateAsync(int articleId, DateTime latestEdit)
        {
            return await _articleRepository.UpdateDateAsync(articleId, latestEdit);
        }

        public async Task<bool> ChangeTitleAsync(int articleId, string newTitle)
        {
            return await _articleRepository.UpdateTitleAsync(articleId, newTitle);
        }

        public async Task<bool> CreateArticleAsync(NewArticleDto newArticleDto)
        {
            var nowTime = DateTime.Now;
            var newArticle = _mapper.Map<Article>(newArticleDto);
            newArticle.PostDate = nowTime;
            newArticle.EditDate = nowTime;
            return await _articleRepository.CreateArticleAsync(newArticle);
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            return await _articleRepository.DeleteArticleAsync(articleId);
        }

        public async Task<ArticleInfoDto?> GetArticleByIdAsync(int articleId)
        {
            var article = await _articleRepository.GetArticleByIdAsync(articleId);
            return _mapper.Map<ArticleInfoDto?>(article);
        }

        public async Task<List<ArticleInfoDto>> GetAllArticlesByKeywordAsync(string keyword)
        {
            var articles = await _articleRepository.GetAllArticlesByKeywordAsync(keyword);
            return _mapper.Map<List<ArticleInfoDto>>(articles);
        }

        public async Task<List<ArticleInfoDto>> GetAllArticlesBySportAsync(Sport sport)
        {
            var articles = await _articleRepository.GetAllArticlesBySportAsync(sport);
            return _mapper.Map<List<ArticleInfoDto>>(articles);
        }
    }
}
