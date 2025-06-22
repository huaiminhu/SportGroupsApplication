using SportGroups.Data.Entities;
using SportGroups.Shared.DTOs.ArticleDTOs;

namespace SportGroups.Data.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Task CreateArticleAsync(Article article);
        Task<Article?> GetArticleByIdAsync(int articleId);

        // 依條件取得指定文章
        Task<List<Article>> GetArticlesByConditionAsync(ArticlesQueryConditions condition);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
    }
}
