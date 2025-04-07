using SportGroups.Business.Services.IServices;
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

        public Task<bool> ChangeContentAsync(int articleId, string newContent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeDateAsync(int articleId, DateTime latestEdit)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeTitleAsync(int articleId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateArticleAsync(ArticleDto articleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteArticleAsync(int articleId)
        {
            throw new NotImplementedException();
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
