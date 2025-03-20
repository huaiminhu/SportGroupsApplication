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

        public Task CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArticle(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticleOfClub(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
