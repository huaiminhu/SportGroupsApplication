using SportGroups.Shared.DTOs.ArticleDTOs;

namespace SportGroups.Business.Services.IServices
{
    public interface IArticleService
    {
        // 依指定條件取得文章
        Task<List<ArticleInfoDto>> GetArticlesByConditionAsync(ArticlesQueryConditions condition);
        Task<ArticleInfoDto?> GetArticleByIdAsync(int articleId);
        Task<int?> CreateArticleAsync(NewArticleDto newArticleDto);
        Task<bool> UpdateArticleAsync(int articleId, ArticleUpdateDto articleUpdateDto);
        Task<bool> DeleteArticleAsync(int articleId);
    }
}
