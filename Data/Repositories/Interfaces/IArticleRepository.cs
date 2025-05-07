using SportGroups.Data.Entities;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Task CreateArticleAsync(Article article);
        Task<Article?> GetArticleByIdAsync(int articleId);

        // 取得指定社團發布的所有文章
        Task<List<Article>> GetAllArticlesOfClubAsync(int clubId);

        // 取得指定運動項目的所有文章
        Task<List<Article>> GetAllArticlesBySportAsync(Sport sport);

        // 取得包含指定關鍵字的所有文章
        Task<List<Article>> GetAllArticlesByKeywordAsync(string keyword);
        void UpdateArticle(Article article);
        //Task<bool> UpdateTitleAsync(int articleId, string newTitle);
        //Task<bool> UpdateContentAsync(int articleId, string newContent);
        //Task<bool> UpdateDateAsync(int articleId, DateTime latestEdit);
        void DeleteArticle(Article article);
    }
}
