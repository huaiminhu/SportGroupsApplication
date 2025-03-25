using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateArticleAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Article?> GetArticleById(int articleId)
        {
            return await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if (existing == null)
            {
                return false;
            }
            _context.Articles.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Article>> GetAllArticleOfClubAsync(int clubId)
        {
            return await _context.Articles.Include(a => a.ClubId == clubId).ToListAsync();
        }

        public async Task<bool> UpdateTitleAsync(int articleId, string newTitle)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if(existing == null)
            {
                return false;
            }
            existing.Title = newTitle;
            _context.Entry(existing).Property(a => a.Title).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateContentAsync(int articleId, string newContent)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if (existing == null)
            {
                return false;
            }
            existing.ArticleContent = newContent;
            _context.Entry(existing).Property(a => a.ArticleContent).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDateAsync(int articleId, DateTime latestEdit)
        {
            var existing = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
            if (existing == null)
            {
                return false;
            }
            existing.EditDate = latestEdit;
            _context.Entry(existing).Property(a => a.EditDate).IsModified = true;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
