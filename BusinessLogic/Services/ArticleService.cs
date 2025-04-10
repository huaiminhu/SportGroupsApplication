using SportGroups.Business.Services.IServices;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
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
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
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

        public async Task<bool> CreateArticleAsync(ArticleDto articleDto)
        {
            Article article = new Article
            {
                Title = articleDto
            }
            return await _articleRepository.CreateArticleAsync(article);
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            return await _articleRepository.DeleteArticleAsync(articleId);
        }

        public Task<ArticleDto?> GetArticleByIdAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleDto>> GetArticlesByKeywordAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleDto>> GetArticlesBySportAsync(Sport sport)
        {
            throw new NotImplementedException();
        }
    }
}
