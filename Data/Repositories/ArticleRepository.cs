using SportGroups.Data.Data;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SportGroups.Shared.DTOs.ArticleDTOs;

namespace SportGroups.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {

        private readonly SportGroupsDbContext _context;
        public ArticleRepository(SportGroupsDbContext context)
        {
            _context = context;
        }

        public async Task CreateArticleAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
        }

        public async Task<Article?> GetArticleByIdAsync(int articleId)
        {
            return await _context.Articles.Include(m => m.Medias).FirstOrDefaultAsync(a => a.ArticleId == articleId);
        }

        public void DeleteArticle(Article article)
        {
            _context.Articles.Remove(article);
        }

        public async Task<List<Article>> GetArticlesByConditionAsync(ArticlesQueryConditions condition)
        {
            var articles = new List<Article>();

            // 回傳指定ClubId的文章
            if (condition.ClubId.HasValue)  
            {
                return articles = await _context.Articles.Where(a => a.ClubId == condition.ClubId).Include(m => m.Medias).ToListAsync();
            }

            // 回傳指定運動項目的文章
            if (condition.Sport.HasValue)  
            {
                return articles = await _context.Articles
                    .Where(a => a.Sport == condition.Sport)
                    .Include(a => a.Medias)
                    .OrderByDescending(a => a.EditDate)
                    .ToListAsync();
            }
            
            // 回傳標題包含指定關鍵字的文章
            if (!string.IsNullOrWhiteSpace(condition.Keyword))
            {
                return articles = await _context.Articles
                    .Where(a => a.Title.Contains(condition.Keyword))
                    .Include(a => a.Medias)
                    .OrderByDescending(a => a.EditDate)
                    .ToListAsync();
            }

            return articles;
        }

        public void UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
        }
    }
}
