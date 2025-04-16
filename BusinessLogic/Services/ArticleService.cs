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
            var mappedData = _mapper.Map<Article>(newArticleDto);
            return await _articleRepository.CreateArticleAsync(mappedData);
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            return await _articleRepository.DeleteArticleAsync(articleId);
        }

        public Task<ArticleInfoDto?> GetArticleByIdAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleInfoDto>> GetArticlesByKeywordAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleInfoDto>> GetArticlesBySportAsync(Sport sport)
        {
            throw new NotImplementedException();
        }
    }
}
