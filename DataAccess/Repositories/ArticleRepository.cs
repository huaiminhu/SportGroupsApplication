using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArticleRepository : IArticleRepository
    {

        private readonly SportGroupsDbContext _context;
        public ArticleRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public Task<bool> CreateArticleAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteArticleAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticleOfClubAsync(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTitleAsync(int articleId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContentAsync(int articleId, string newContent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDateAsync(int articleId, DateTime latestEdit)
        {
            throw new NotImplementedException();
        }
    }
}
